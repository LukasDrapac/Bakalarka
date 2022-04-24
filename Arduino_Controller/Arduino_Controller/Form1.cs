using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using AForge.Video.DirectShow;
using System.Diagnostics;


namespace Arduino_Controller
{
    public partial class Form1 : Form
    {        
        String[] ports;

        string rootImageFolderPath;
        string currentFolderPath;
        string numberOfSteps;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        ArduinoCommunication arduinoComm = new ArduinoCommunication();
        ProcessImage processImage = new ProcessImage();
        public Form1()
        {
            InitializeComponent();
            controllsAfterStart();
            initSerialPortsComboBox();
            qualityComboboxInit();            
        }        

        //Manualni porizeni snimku
        private void makeSnapshot_Click(object sender, EventArgs eventArgs)
        {
            Bitmap bmp = videoSourcePlayer.GetCurrentVideoFrame();
            pictureBox.Image = bmp;
        }       

        //Pripojeni k Arduinu a webkamere
        private void connectButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ujistěte se, že v přípravku není vložena kraslice.");
            string selectedPort = serialPorts.GetItemText(serialPorts.SelectedItem);
            arduinoComm.connectToArduino(selectedPort);
            connectCamera();
            controllsAfterConnection();
        }

        //Odpojeni Arduina a webkamery
        private void disconnectButton_Click(object sender, EventArgs e)
        {   
            arduinoComm.disconnectArduino();
            disconnectCamera();
            controllsAfterStart();
        }
        
        //Spusti zmereni vysky kraslice
        private void measureButton_Click(object sender, EventArgs e)
        {
            arduinoComm.measureHeight();
        }

        //Inicializace ComboBoxu s vyberem poctu snimku
        private void qualityComboboxInit()
        {
            string[] quality = {"5", "10", "15", "20", "25" };
            foreach (string possibility in quality)
            {
                qualitySelectComboBox.Items.Add(possibility);
            }
        }

        private void qualitySelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {      
            int selectedQuality = qualitySelectComboBox.SelectedIndex;            
            qualitySelect(selectedQuality);
            controllsReadyToStartImaging();
        }

        //Spusteni cyklu porizovani snimku
        private void StartButton_Click(object sender, EventArgs e)
        {
            startCycle();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                camBox.Items.Add(filterInfo.Name);
            }

            camBox.SelectedIndex = 0;
            Console.WriteLine("Video devices found");
        }        

        private void folderBrowsingButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if(browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rootImageFolderPath = browserDialog.SelectedPath;                
            }
        }

        //Vytvori novou slozku ve zvolenem lokaci 
        private void createFolder()
        {
            currentFolderPath = Path.Combine(rootImageFolderPath, inventoryNumber.Text);
            Console.WriteLine(currentFolderPath);
            Directory.CreateDirectory(currentFolderPath);
        }

        //Zacne cyklus porizovani snimku a otaceni kraslice. Musi byt specifikovane misto pro ukladani snimku a inventarni cislo kraslice
        private async void startCycle()
        {
            if (inventoryNumber.Text != "" & currentFolderPath != "")
            {
                createFolder();
                int runs = 1600 / int.Parse(numberOfSteps);
                controllsDuringImaging();

                int imageNumber = 1;
                for (int n = 0; n < runs; n++)
                {
                    Task task = arduinoComm.makeStep(numberOfSteps);
                    await task;
                    await Task.Delay(500);
                    takeSnapshot(imageNumber);
                    imageNumber++;
                       
                }
                Console.WriteLine("Cycle finished succesfully");
                controllsReadyToStartImaging();
            }
            else
            {
                MessageBox.Show("Nebyla zvolena složka se snímky kraslic nebo inventární číslo kraslice");
            }
            Console.WriteLine(currentFolderPath);
            pictureBox.Image = processImage.processImage(currentFolderPath, inventoryNumber.Text);
        }

        //Volba poctu snimku porizenych behem jednoho cyklu
        private void qualitySelect(int quality)
        {
            switch (quality)
            {
                case 0:
                    numberOfSteps = "320";
                    break;
                case 1:
                    numberOfSteps = "160";
                    break;
                case 2:
                    numberOfSteps = "106";
                    break;
                case 3:
                    numberOfSteps = "080";
                    break;
                case 4:
                    numberOfSteps = "064";
                    break;
            }

            Console.WriteLine(numberOfSteps);
        }       

        //Metoda zaznamena obsazene COM porty do ComboBoxu
        private void initSerialPortsComboBox()
        {
            ports = arduinoComm.getAvailablePorts();
            Console.WriteLine(ports);
            foreach (string port in ports)
            {
                serialPorts.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    serialPorts.SelectedItem = ports[0];
                }
            }
        }

        //Metoda poridi snimek a ulozi ho do zvolene slozky
        private void takeSnapshot(int imageNumber)
        {
            Console.WriteLine("Snapshot taken");
            Bitmap snapshot = videoSourcePlayer.GetCurrentVideoFrame();
            pictureBox.Image = snapshot;
            string path = currentFolderPath + "/" + inventoryNumber.Text + "_" + imageNumber.ToString() + ".jpg";
            snapshot.Save(path);
            snapshot.Dispose();
        }

        //Povolene prvky UI po pripojeni k webce a Arduinu
        private void controllsAfterConnection()
        {
            serialPorts.Enabled = false;
            camBox.Enabled = false;
            connectButton.Enabled = false;
            StartButton.Enabled = false;
            folderBrowsingButton.Enabled = false;
            inventoryNumber.Enabled = false;

            disconnectButton.Enabled = true;
            makeSnapshot.Enabled = true;
            qualitySelectComboBox.Enabled = true;
        }

        //Povolene prvky UI po spusteni aplikace
        private void controllsAfterStart()
        {
            disconnectButton.Enabled = false;
            makeSnapshot.Enabled = false;
            qualitySelectComboBox.Enabled = false;
            StartButton.Enabled = false;
            folderBrowsingButton.Enabled = false;
            inventoryNumber.Enabled = false;

            connectButton.Enabled = true;
            camBox.Enabled = true;
            serialPorts.Enabled = true;
        }

        //Povolene prvky UI behem cyklu pozirovani snimku
        private void controllsDuringImaging()
        {
            disconnectButton.Enabled = false;
            makeSnapshot.Enabled = false;
            qualitySelectComboBox.Enabled = false;
            StartButton.Enabled = false;
            connectButton.Enabled = false;
            camBox.Enabled = false;
            serialPorts.Enabled = false;
            folderBrowsingButton.Enabled = false;
            inventoryNumber.Enabled = false;
        }
        //Povolene prvky UI po nastaveni vsech parametru
        private void controllsReadyToStartImaging()
        {
            serialPorts.Enabled = false;
            camBox.Enabled = false;
            connectButton.Enabled = false;

            folderBrowsingButton.Enabled = true;
            inventoryNumber.Enabled = true;
            StartButton.Enabled = true;
            disconnectButton.Enabled = true;
            makeSnapshot.Enabled = true;
            qualitySelectComboBox.Enabled = true;
        }       

        //Pripojeni k webce
        private void connectCamera()
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camBox.SelectedIndex].MonikerString);
            videoCaptureDevice.ProvideSnapshots = true;

            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;

            //videoCaptureDevice.SnapshotResolution = snapshotCapabilities[0];
            //videoCaptureDevice.VideoResolution = videoCapabilities[0];
            //
            videoSourcePlayer.VideoSource = videoCaptureDevice;
            videoSourcePlayer.Start();
            camConnectCheckBox.Checked = true;
            Console.WriteLine("Camera connected");
        }

        //Odpojeni od webky
        private void disconnectCamera()
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            videoSourcePlayer.VideoSource = null;
            camConnectCheckBox.Checked = false;
            Console.WriteLine("Camera disconnected");
        }

        private void openGaleryButton_Click(object sender, EventArgs e)
        {
            string testingPath = "C:/Users/drapa/OneDrive/Plocha/Image_Crop/Images";
            
            galeryForm galery = new galeryForm(testingPath);
            galery.Show();

            //string folderName;
            //for(int i = 1; i <= 326; i++)
            //{
            //    if(i < 10)
            //    {
            //        folderName = "00" + i;
            //    }
            //    else if(i >= 10 && i <= 99)
            //    {
            //        folderName = "0" + i;
            //    }
            //    else
            //    {
            //        folderName = "" + i;
            //    }
            //    Directory.CreateDirectory("C:/Users/drapa/OneDrive/Plocha/Image_Crop/Tests_folder/KR_" + folderName);
            //}
        }
    }
}


