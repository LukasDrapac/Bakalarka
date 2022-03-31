using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Arduino_Controller
{
    class Arduino_Communication
    {
        private String[] serialPorts;
        SerialPort port;

        string numberOfSteps;

        public void sayHello()
        {
            Console.WriteLine("Hello");
        }

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
                int numberOfSteps = 000;
                string message = makeMessage(commandString, numberOfSteps);
                Console.WriteLine(message);
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
        public async Task makeStep(int steps)
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

        //Metoda sklada zpravy, ktere jsou posilany pomoci seriove komunikace Arduinu
        private string makeMessage(string commandString, int steps)
        {
            string message = commandString + "/" + steps + "\n";
            Console.WriteLine(message);
            return message;
        }

        //Sklada zpravy, ktere by mely prijit po seriove komunikaci z Arduina, slouzi pro overeni, ze Arduino splnilo pozadavek
        private string makeDoneMessage(string commandString, int steps)
        {
            string message = commandString + "/" + steps + "/DONE";
            return message;
        }
    }
}
