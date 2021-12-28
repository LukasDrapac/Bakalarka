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
using System.Threading;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Arduino_Controller
{
    public partial class Form1 : Form
    {
        String[] ports;
        SerialPort port;

        string rootImageFolderPath;
        string folderPath;
        string commandString;
        string numberOfSteps;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;


        public Form1()
        {
            InitializeComponent();
            controllsAfterStart();
            getAvailablePorts();
            qualityComboboxInit();
        }        

        private void makeSnapshot_Click(object sender, EventArgs eventArgs)
        {
            Bitmap bmp = videoSourcePlayer.GetCurrentVideoFrame();
            pictureBox.Image = bmp;
        }       

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectToArduino();
            connectCamera();
            controllsAfterConnection();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            disconnectArduino();
            disconnectCamera();
            controllsAfterStart();
        }    
        
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
            folderPath = Path.Combine(rootImageFolderPath, inventoryNumber.Text);
            Console.WriteLine(folderPath);
            Directory.CreateDirectory(folderPath);
        }

        //Zacne cyklus porizovani snimku a otaceni kraslice. Musi byt specifikovane misto pro ukladani snimku a inventarni cislo kraslice
        private async void startCycle()
        {
            if (inventoryNumber.Text != "" & folderPath != "")
            {
                createFolder();

                commandString = "CLK00";
                string message = makeMessage();
                int runs = 1600 / int.Parse(numberOfSteps);
                controllsDuringImaging();

                int imageNumber = 1;
                for (int n = 0; n < runs; n++)
                {
                    takeSnapshot(imageNumber);
                    imageNumber++;

                    await Task.Delay(1000);
                    port.WriteLine(message);


                    string answer = port.ReadLine();

                    if (answer == makeDoneMessage())
                    {
                        connectedCheckBox.Checked = true;
                        Console.WriteLine(answer);
                        await Task.Delay(1000);
                    }
                    else
                    {
                        Console.WriteLine("Step failed");
                    }
                }
                controllsReadyToStartImaging();
            }
            else
            {
                MessageBox.Show("Nebyla zvolena složka se snímky kraslic nebo inventární číslo kraslice");
            }
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

        //Metoda sklada zpravy, ktere jsou posilany pomoci seriove komunikace Arduinu
        private string makeMessage()
        {
            string message = commandString + "/" + numberOfSteps + "\n";
            Console.WriteLine(message);
            return message;
        }

        //Sklada zpravy, ktere by mely prijit po seriove komunikaci z Arduina, slouzi pro overeni, ze Arduino splnilo pozadavek
        private string makeDoneMessage()
        {
            string message = commandString + "/" + numberOfSteps + "/DONE";
            return message;
        }

        //Metoda zaznamena obsazene COM porty
        private void getAvailablePorts()
        {
            ports = SerialPort.GetPortNames();

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
            string path = folderPath + "/" + inventoryNumber.Text + "_" + imageNumber.ToString() + ".jpg";
            snapshot.Save(path);
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

        //Pripojeni k Arduinu
        private async void connectToArduino()
        {
            string selectedPort = serialPorts.GetItemText(serialPorts.SelectedItem);
            port = new SerialPort(selectedPort);
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            try
            {
                port.Open();

                commandString = "START";
                string message = makeMessage();
                Console.WriteLine("APP:  " + message);
                port.WriteLine(message);

                await Task.Delay(1000);

                string answer = port.ReadLine();
                Console.WriteLine("Arduino:  " + answer);

                if (answer == makeDoneMessage())
                {
                    connectedCheckBox.Checked = true;
                    Console.WriteLine("Connected!");
                }
                else
                {
                    disconnectArduino();
                    Console.WriteLine("Not Connected");
                }
            }
            catch { }
        }

        //Pripojeni k webce
        private void connectCamera()
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camBox.SelectedIndex].MonikerString);
            videoCaptureDevice.ProvideSnapshots = true;

            snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;
            videoCapabilities = videoCaptureDevice.VideoCapabilities;

            //foreach(VideoCapabilities info in snapshotCapabilities)
            //{
            //    snapshotResolutionComBox.Items.Add(info.FrameSize);
            //}

            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;

            videoCaptureDevice.SnapshotResolution = snapshotCapabilities[0];
            videoCaptureDevice.VideoResolution = videoCapabilities[0];

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

        //odpojeni od Arduina
        private void disconnectArduino()
        {
            port.Close();

            connectedCheckBox.Enabled = false;
            Console.WriteLine("Arduino disconnected");
        }

    }
}


