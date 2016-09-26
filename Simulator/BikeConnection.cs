using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.Mime;
using System.Threading;

namespace BikeAppA3
{
    public class BikeConnection : Bike
    {
        public SerialPort sp;
        public List<String[]> data = new List<String[]>();
        public bool Connected { get; set; }

        public BikeConnection()
        {

            String[] pn = SerialPort.GetPortNames();
            if (pn.Length == 0)
            {
                Console.WriteLine("there is no COM port available, booting Simulation");
                Connected = false;
            }
            else
            {
                Connected = true;
                sp = new SerialPort(pn[0], 9600);
                sp.Open();
                Console.WriteLine("connected!");
                
                Thread listenThread = new Thread(Listen);
                listenThread.Start();
            }
        }

        public void Listen()
        {
            int i = 0;
            while (true)
            {
                String incomingData = sp.ReadLine();
                String sep = "\t";
                String[] letters = incomingData.Split(sep.ToCharArray());
                data.Add(letters);
                Thread.Sleep(500);
                foreach (var a in data.ElementAt(i))
                    Console.WriteLine(a);

                Console.WriteLine(data.Count);
                i++;
            }
        }

        public string Id { get; set; }
        public double Pulse { get; set; }
        public double RPM { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public double Energy { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Stopwatch { get; set; }
        public double PowerUsage { get; set; }
        public string Chatbox { get; set; }
        public SerialPort Port { get; set; }

        public List<string> ReadData()
        {
            Listen();
            System.Collections.Generic.List<string> data = new List<string>();
            try
            {
                data.Add(Id.ToString());
                data.Add(Pulse.ToString());
                data.Add(Port.ToString());
                data.Add(Speed.ToString());
                data.Add(Distance.ToString());
                data.Add(Energy.ToString());
                data.Add(Time.ToString());
                data.Add(Stopwatch.ToString());
                data.Add(PowerUsage.ToString());
                data.Add(Chatbox);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            return data;
        }

        public void SendCommand(string command)
        {
            sp.WriteLine(command);
        }

        public string SaveToDatabase(string query)
        {
            throw new NotImplementedException();
        }
    }
}