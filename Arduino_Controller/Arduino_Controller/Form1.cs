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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Arduino_Controller
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        string commandString;
        string numberOfSteps;
        string imageFolderPath = "C:/Users/drapa_kmrggum/Desktop/Fotky";

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
                    isConnected = true;
                    connectedCheckBox.Checked = true;
                    Console.WriteLine("Connected!");
                }
                else
                {
                    disconnectArduino();
                    isConnected = false;
                    Console.WriteLine("Not Connected");
                }
            }
            catch { }
        }

        private void connectCamera()
        {         
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camBox.SelectedIndex].MonikerString);
            videoCaptureDevice.ProvideSnapshots = true;

            snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;
            videoCapabilities = videoCaptureDevice.VideoCapabilities;

            foreach(VideoCapabilities info in snapshotCapabilities)
            {
                snapshotResolutionComBox.Items.Add(info.FrameSize);
            }

            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;

            videoCaptureDevice.SnapshotResolution = snapshotCapabilities[0];
            videoCaptureDevice.VideoResolution = videoCapabilities[0];

            videoSourcePlayer.VideoSource = videoCaptureDevice;
            videoSourcePlayer.Start();
            camConnectCheckBox.Checked = true;
            Console.WriteLine("Camera connected");
        }

        private void disconnectCamera()
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            videoSourcePlayer.VideoSource = null;
            camConnectCheckBox.Checked = false;
            Console.WriteLine("Camera disconnected");
        }

        private void disconnectArduino()
        {
            port.Close();
            isConnected = false;

            connectedCheckBox.Enabled = false;
            Console.WriteLine("Arduino disconnected");
        }

        private void makeSnapshot_Click(object sender, EventArgs eventArgs)
        {
            Bitmap bmp = videoSourcePlayer.GetCurrentVideoFrame();
            pictureBox.Image = bmp;
            //string path = imageFolderPath + "/" + imageName.ToString() + ".jpg";
            //bmp.Save(path);
            //imageName++;
        }

        private void takeSnapshot(int imageNumber)
        {
            Console.WriteLine("Snapshot taken");
            Bitmap snapshot = videoSourcePlayer.GetCurrentVideoFrame();
            pictureBox.Image = snapshot;
            string path = imageFolderPath + "/" + inventoryNumber.Text + "_" + imageNumber.ToString() + ".jpg";
            snapshot.Save(path);
        }


        private void controllsAfterConnection()
        {            
            serialPorts.Enabled = false;
            camBox.Enabled = false;
            connectButton.Enabled = false;
            StartButton.Enabled = false;

            disconnectButton.Enabled = true;
            makeSnapshot.Enabled = true;
            qualitySelectComboBox.Enabled = true;
        }

        private void controllsAfterStart()
        {
            disconnectButton.Enabled = false;
            makeSnapshot.Enabled = false;
            qualitySelectComboBox.Enabled = false;
            StartButton.Enabled = false;
            
            connectButton.Enabled = true;
            camBox.Enabled = true;
            serialPorts.Enabled = true;
        }

        private void controllsDuringImaging()
        {
            disconnectButton.Enabled = false;
            makeSnapshot.Enabled = false;
            qualitySelectComboBox.Enabled = false;
            StartButton.Enabled = false;
            connectButton.Enabled = false;
            camBox.Enabled = false;
            serialPorts.Enabled = false;
        }
        private void controllsReadyToStartImaging()
        {
            serialPorts.Enabled = false;
            camBox.Enabled = false;
            connectButton.Enabled = false;

            StartButton.Enabled = true;
            disconnectButton.Enabled = true;
            makeSnapshot.Enabled = true;
            qualitySelectComboBox.Enabled = true;
        }

        void getAvailablePorts()
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

        private string makeMessage()
        {
            string message = commandString + "/" + numberOfSteps + "\n";
            Console.WriteLine(message);
            return message;
        }

        private string makeDoneMessage()
        {
            string message = commandString + "/" + numberOfSteps + "/DONE";
            return message;
        }
        private void qualityComboboxInit()
        {
            string[] quality = {"Nejnižší", "Nízká", "Střední", "Vysoká", "Nejvyšší" };
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
        //private void snapshotResolutionComBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(qualitySelectComboBox.SelectedIndex == 0)
        //    {
        //        
        //        videoCapabilities = videoCaptureDevice.VideoCapabilities;
        //        snapshotCapabilities = videoCaptureDevice.SnapshotCapabilities;
        //
        //        videoCaptureDevice.SnapshotResolution = snapshotCapabilities[snapshotResolutionComBox.SelectedIndex];
        //        videoCaptureDevice.VideoResolution = videoCapabilities[snapshotResolutionComBox.SelectedIndex];
        //    }
        //
        //}

        private async void StartButton_Click(object sender, EventArgs e)
        {
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
                await Task.Delay(1000);

                string answer = port.ReadLine();

                if (answer == makeDoneMessage())
                {
                    isConnected = true;
                    connectedCheckBox.Checked = true;
                    Console.WriteLine(answer);
                }
                else
                {
                    Console.WriteLine("Step failed");
                }                
            }
            controllsReadyToStartImaging();
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
    }
}


