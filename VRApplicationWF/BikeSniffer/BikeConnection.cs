using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

namespace BikeApplication
{
    class BikeConnection
    {
        private readonly SerialPort sp;

        static readonly ASCIIEncoding asen = new ASCIIEncoding();


        public List<string[]> data = new List<string[]>();

        private BinaryReader reader;
        private readonly BinaryWriter writer;
        
        public BikeConnection()
        {

            //TcpClient client = new TcpClient("", 1330);
            // reader = new BinaryReader(client.GetStream());
            // writer = new BinaryWriter(client.GetStream());

            String[] pn = SerialPort.GetPortNames();
          

                sp = new SerialPort(pn[0], 9600);
                sp.Open();
                Console.WriteLine("connected!");     
            
        }

        public void sendCommand(string message)
        {
            sp.WriteLine(message);
        }

        public string Listen()
        {
                return sp.ReadLine();
        }


        public void SendTxtMessageToServer(string s)
        {
            byte[] jsonBytes = asen.GetBytes(s);

            writer.Write(BitConverter.GetBytes(jsonBytes.Length));
            writer.Write(jsonBytes);
        }

    }

}