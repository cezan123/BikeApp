using BikeApplication;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using VRApplicationWF.BikeSniffer;
using VRApplicationWF.VirtualReality.Scripts;

namespace VRApplicationWF.VirtualReality.Forms
{
    public partial class Form1 : Form
    {
        readonly SessionList sList;
        readonly Connection cw;
        private Simulation sim;
        private BikeConnection bike;

        private GUI gui;

        public Form1()
        {


            InitializeComponent();


            cw = new Connection();

            String test = cw.WriteReadData(JSONMethods.SessionList());



            sList = JsonConvert.DeserializeObject<SessionList>(test);


            GenerateTable();
        }

        private void GenerateTable()
        {

            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Host", typeof(string));

            foreach (Data d in sList.data)
            {

                table.Rows.Add(d.id, d.clientinfo.host);

            }

            dataGridView1.DataSource = table;
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                Password pwframe = new Password {StartPosition = FormStartPosition.CenterParent};
                pwframe.ShowDialog();

                Console.WriteLine("chosen row: " + e.RowIndex);
                string tunnel = cw.WriteReadData(JSONMethods.CreateTunnel(sList.data[e.RowIndex].id, pwframe.textBox));

                string id = tunnel.Substring(50, 36);
                Console.WriteLine(id);


                gui = new GUI(cw, id);
                gui.Show();


                String[] pn = SerialPort.GetPortNames();
                Thread thread;
                if (pn.Length == 0)
                {
                    Console.WriteLine("there is no COM port available, starting the simulation");
                    sim = new Simulation();
                    thread = new Thread(ActionSim);
                }
                else
                {
                    Console.WriteLine("COM port available, connecting to the bike...");
                    bike = new BikeConnection();
                    thread = new Thread(ActionBike);
                }
             
                thread.Start();
                this.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("There isn't a stable connection, ERROR (restart sim.bat)");
            }
        }

        private void ActionSim()
        {
            while (true)
            {
                sim.GenerateRandomSt();
                string simdata = sim.SendCommand();
                Console.WriteLine(simdata);
                string[] data = simdata.Split("\t".ToCharArray());
                gui.ChangeSpeed(double.Parse(data[2]), data[7], double.Parse(data[3])*0.1, double.Parse(data[5]) * 0.238);
               // sim.SendTxtMessageToServer(simdata);
              

                Thread.Sleep(1000);
            }
        }

        private void ActionBike()
        {
            while (true)
            {
                bike.sendCommand("st");
                string message = bike.Listen();
                Console.WriteLine(message);
                string sep = "\t";
                string[] letters = message.Split(sep.ToCharArray());
    
              
                gui.ChangeSpeed(double.Parse(letters[2])*0.1f, letters[6], double.Parse(letters[3]) * 0.1, double.Parse(letters[5])*0.238);

                //bike.SendTxtMessageToServer(message);

                Thread.Sleep(100);
            }
        }

    }


}
