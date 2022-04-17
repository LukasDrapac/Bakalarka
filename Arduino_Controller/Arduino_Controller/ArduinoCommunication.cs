using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Arduino_Controller
{
    class ArduinoCommunication
    {
        private String[] serialPorts;
        SerialPort port;

        int offset;
        string numberOfSteps;

        //Vrati pole zapojenych COM portu
        public string[] getAvailablePorts()
        {
            serialPorts = SerialPort.GetPortNames();
            return serialPorts;
        }

        //Pripojeni k Arduinu
        public async void connectToArduino(string selectedPort)
        {
            
            port = new SerialPort(selectedPort);
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            try
            {
                port.Open();

                string commandString = "START";
                string numberOfSteps = "000";
                string message = makeMessage(commandString, numberOfSteps);
                port.WriteLine(message);

                await Task.Delay(1000);

                string answer = port.ReadLine();
                Console.WriteLine("Arduino:  " + answer);

                if (answer == makeDoneMessage(commandString, numberOfSteps))
                {                    
                    Console.WriteLine("Connected!");                    
                }
                else
                {                    
                    Console.WriteLine("Not Connected");                    
                }

                //offset = measureHeight();
            }
            catch { }
        }

        //odpojeni od Arduina
        public void disconnectArduino()
        {
            port.Close();            
            Console.WriteLine("Arduino disconnected");
        }

        //Zacne cyklus porizovani snimku a otaceni kraslice. Musi byt specifikovane misto pro ukladani snimku a inventarni cislo kraslice
        public async Task makeStep(string steps)
        {
            string commandString = "CLK00";
            string command = makeMessage(commandString, steps);

            port.WriteLine(command);
            await Task.Delay(500);
            string answer = port.ReadLine();

             if (answer == makeDoneMessage(commandString, steps))
             {
                 Console.WriteLine(answer);
             }
             else
             {
                 Console.WriteLine("Step failed");
             }
                        
        }

        public int measureHeight()
        {
            string commandString = "MEASR";
            string command = makeMessage(commandString, "000");

            port.WriteLine(command);
            string answer = port.ReadLine();
            Console.WriteLine(answer);
            int distance = int.Parse(answer.Substring(answer.IndexOf("/") + 1, 3));
            //Console.WriteLine(distance);
            return distance;
        }

        //Metoda sklada zpravy, ktere jsou posilany pomoci seriove komunikace Arduinu
        private string makeMessage(string commandString, string steps)
        {
            string message = commandString + "/" + steps + "\n";
            Console.Write(message);
            return message;
        }

        //Sklada zpravy, ktere by mely prijit po seriove komunikaci z Arduina, slouzi pro overeni, ze Arduino splnilo pozadavek
        private string makeDoneMessage(string commandString, string steps)
        {
            string message = commandString + "/" + steps + "/DONE";
            return message;
        }
    }
}
