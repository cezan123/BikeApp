using System.Windows.Forms;

namespace VRApplicationWF
{
    public partial class Password : Form
    {
        public string textBox { get; private set; }

        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBox = textBox1.Text;
            Close();
        }

      
    }
}
