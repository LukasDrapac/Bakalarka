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
            qualitySelect();
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

                qualitySelect();

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
                    enableControls();
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
            redLEDButton.Enabled = false;
            redLEDCheckBox.Enabled = false;
            greenLEDButton.Enabled = false;
            greenLEDCheckBox.Enabled = false;
            yellowLEDButton.Enabled = false;
            yellowLEDCheckBox.Enabled = false;
            connectButton.Enabled = true;
        }

        private void enableControls()
        {
            redLEDButton.Enabled = true;
            greenLEDButton.Enabled = true;
            yellowLEDButton.Enabled = true;
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

        private void redLEDButton_Click(object sender, EventArgs e)
        {
            commandString = "LEFT0";
            string message = makeMessage();
            port.WriteLine(message);
            Console.WriteLine("API:  " + message);

            redLEDCheckBox.Checked = true;

            string answer = port.ReadLine();
            Console.WriteLine("Arduino:  " + answer);

            if(answer == makeDoneMessage())
            {
                redLEDCheckBox.Checked = false;
            }
            else
            {
                Console.WriteLine(answer + " is unknown command");
            }
        }

        private void greenLEDButton_Click(object sender, EventArgs e)
        {
            commandString = "HOME0";
            string message = makeMessage();
            port.WriteLine(message);
            Console.WriteLine("API:  " + message);

            redLEDCheckBox.Checked = true;

            string answer = port.ReadLine();
            Console.WriteLine("Arduino:  " + answer);

            if (answer == makeDoneMessage())
            {
                redLEDCheckBox.Checked = false;
            }
            else
            {
                Console.WriteLine(answer + " is unknown command");
            }
        }

        private void yellowLEDButton_Click(object sender, EventArgs e)
        {
            commandString = "RIGHT";
            string message = makeMessage();
            port.WriteLine(message);
            Console.WriteLine("API:  " + message);

            redLEDCheckBox.Checked = true;

            string answer = port.ReadLine();
            Console.WriteLine("Arduino:  " + answer);

            if (answer == makeDoneMessage())
            {
                redLEDCheckBox.Checked = false;
            }
            else
            {
                Console.WriteLine(answer + " is unknown command");
            }
        }

        private void qualitySelect()
        {
            int quality = 1;

            switch (quality)
            {
                case 0:
                    numberOfSteps = "010"; 
                    break;
                case 1:
                    numberOfSteps = "030";
                    break;
                case 2:
                    numberOfSteps = "050";
                    break;
                case 3:
                    numberOfSteps = "070";
                    break;
                case 4:
                    numberOfSteps = "090";
                    break;
            }
        }

        private string makeMessage()
        {
            string message = commandString + "/" + numberOfSteps + "\n";
            return message;
        }

        private string makeDoneMessage()
        {
            string message = commandString + "/" + numberOfSteps + "/DONE";
            return message;
        }
    }
}


