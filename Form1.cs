using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace csanimation
{
    public partial class Form1 : Form
    {
        bool animationEnabled = false;


        public Form1()
        {
            Program.f1 = this;

            InitializeComponent();

        }

        void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            animationEnabled = !animationEnabled;
            buttonStart.Enabled = !buttonStart.Enabled;
            buttonStop.Enabled = !buttonStop.Enabled;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f2.Close();
        }
    }
}
