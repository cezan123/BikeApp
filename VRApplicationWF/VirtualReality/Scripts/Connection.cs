using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace VRApplicationWF
{
    internal class Connection
    {
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;
        private readonly ASCIIEncoding asen = new ASCIIEncoding();

        public Connection()
        {


            try
            {
                TcpClient tcpclnt = new TcpClient("84.24.41.72", 6666);
                Console.WriteLine("Connecting.....");


                Console.WriteLine("Connected");

                reader = new BinaryReader(tcpclnt.GetStream());
                writer = new BinaryWriter(tcpclnt.GetStream());

            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.StackTrace);
            }
        }

        public string WriteReadData(string s)
        {
            byte[] jsonBytes = asen.GetBytes(s);


            writer.Write(BitConverter.GetBytes(jsonBytes.Length));
            writer.Write(jsonBytes);

            int packLen = reader.ReadInt32();
            byte[] bytes = reader.ReadBytes(packLen);
            return Encoding.ASCII.GetString(bytes);
        }

        public void WriteData(string s)
        {
            byte[] jsonBytes = asen.GetBytes(s);


            writer.Write(BitConverter.GetBytes(jsonBytes.Length));
            writer.Write(jsonBytes);
        }
    }
}
