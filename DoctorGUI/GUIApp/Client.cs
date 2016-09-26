using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.PowerPacks;

namespace DoctorGUI.GUIApp
{

    public partial class Client : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private int tabSelected = 0;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private List<int> lijst = new List<int>();

        public Client()
        {
           
            InitializeComponent();

            GenerateClientTable();

            



        }

    

        private void GenerateClientTable()
        {
            int columcount = 0;
            int rowcount = 0;
            tableLayoutPanel1.RowCount = lijst.Count/2;
            for (int i = 0; i < 20; i++)
            {
                lijst.Add(i);
            }

            foreach (int i in lijst)
            {
             
                PictureBox pw = new PictureBox
                {
                    Anchor = AnchorStyles.None,
                    ImageLocation = "https://www.reikicirkel.nl/upload/1895/Bestuur/pasfoto%20Wienkew.jpg",
                    Width = 148,
                    Height = 184
                };
                //pw.MouseHover += new EventHandler(HoverMouseAction);
              //  pw.MouseHover += new EventHandler(HoverMouseAction);
                pw.Click += new EventHandler(ClickClientAction);

                tableLayoutPanel1.Controls.Add(pw,columcount, rowcount);
                columcount++;
                if (columcount != 3) continue;
                columcount = 0;
                rowcount++;

            }
        }

        private void ClickClientAction(object sender, EventArgs e)
        {
            clientPanel.Visible = true;
            SwitchPage(1);
        }

        private void HoverMouseAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void HoverMouseAction(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("www.4chan.org");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchPage(0);
        }

        private void SwitchPage(int newPageNumber)
        {
            if (newPageNumber != tabSelected)
            {
                switch (newPageNumber)
                {
                    case 0:
                        // Home screen
                        homeButton.BackColor = Color.FromArgb(0, 108, 1);
                        clientPanel.Visible = false;
                        tableLayoutPanel1.Visible = true;
                        break;
                    case 1:
                        dataCenterButton.BackColor = Color.FromArgb(0, 108, 1);
                        break;
                }
                switch (tabSelected)
                {
                    case 0:
                        // Home screen
                        tableLayoutPanel1.Visible = false;
                        homeButton.BackColor = Color.Transparent;
                        break;
                    case 1:
                        dataCenterButton.BackColor = Color.FromArgb(0, 108, 1);
                        break;
                }
                tabSelected = newPageNumber;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            SwitchPage(1);
        }
    }
}
