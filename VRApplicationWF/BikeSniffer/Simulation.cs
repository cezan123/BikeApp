using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace VRApplicationWF.BikeSniffer
{

    class Simulation
    {

        private static readonly Random rnd = new Random();
        private string st;
        static readonly ASCIIEncoding asen = new ASCIIEncoding();


        public List<string[]> data = new List<string[]>();

        private BinaryReader reader;
        private readonly BinaryWriter writer;


        public Simulation()
        {
            try
            {
                //TcpClient client = new TcpClient("145.48.114.75", 6666);
                //reader = new BinaryReader(client.GetStream());
                //writer = new BinaryWriter(client.GetStream());

                GenerateRandomSt();
            }
            catch(SocketException)
            {
                Console.WriteLine("Er is geen verbinding mogelijk met de server, ERROR");
            }



        }





        public string SendCommand()
        {
            GenerateRandomSt();
            Console.WriteLine(st);
            return st;
        
        }

        public void GenerateRandomSt()
        {
            int pulse = RndInt(0, 120);
            int RPM = RndInt(0, 110);
            double speed = RndDouble(0, 60);
            double distance = RndDouble(0, 999);
            int watt = RndInt(0, 200);
            int burnedEnergy = RndInt(0, 999);

            int minutes = RndInt(0, 59);
            int seconds = RndInt(0, 59);
            string datetime = string.Format($"{minutes}:{seconds}");

            int actualwatt = RndInt(0, 200);

            st = string.Format($"{pulse}\t{RPM}\t{speed}\t{distance}\t{watt}\t{burnedEnergy}\t{datetime}\t{actualwatt}");
        }




        //{pulse in HZ}{rpm}{speed in 0.1km/h}{distance in 0.1 km}
        //{requested power}{energy in kJ}{time in minutes:seconds}{actual power}.


        private static double RndDouble(double min, double max)
        {
            double range = max - min;
            double difference = 0 + min;
            double newDouble = (rnd.NextDouble() * range) + difference;
            return newDouble;
        }

        private static int RndInt(int min, int max)
        {
            var newInt = rnd.Next(min, max);
            return newInt;
        }

        public void SendTxtMessageToServer(string s)
        {
            byte[] jsonBytes = asen.GetBytes(s);

            writer.Write(BitConverter.GetBytes(jsonBytes.Length));
            writer.Write(jsonBytes);
        }
    }
}
