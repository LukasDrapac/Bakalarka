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

namespace Arduino_Controller
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        string commandString;
        string numberOfSteps;

        public Form1()
        {
            InitializeComponent();
            disableControls();
            getAvailablePorts();
            qualityComboboxInit();
        }

        private void connectToArduino()
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
                Console.WriteLine("API:  " + message);
                port.WriteLine(message);                

                Thread.Sleep(1000);

                string answer = port.ReadLine();
                Console.WriteLine("Arduino:  " + answer);

                if (answer == makeDoneMessage())
                {
                    isConnected = true;
                    connectedCheckBox.Checked = true;
                    controllsAfterStart();
                    Console.WriteLine("API:  Connected!");
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

        private void disconnectArduino()
        {
            port.Close();
            isConnected = false;

            disableControls();

            Console.WriteLine("Arduino disconnected");
        }


        private void disableControls()
        {            
            connectButton.Enabled = true;
        }

        private void controllsAfterStart()
        {
            connectButton.Enabled = false;
            disconnectButton.Enabled = true;


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
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            disconnectArduino();
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
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            commandString = "CLK00";
            string message = makeMessage();
            int runs = 1600 / int.Parse(numberOfSteps);

            for (int n = 0; n < runs; n++)
            {
                port.WriteLine(message);
                Thread.Sleep(500);
            }
        }
    }
}


