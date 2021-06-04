using System;
using System.Drawing;
using System.Windows.Forms;

namespace csanimation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Program.f2 = this;

            InitializeComponent();
            progressBar1.BringToFront();
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;  
            this.TransparencyKey = this.BackColor;

            pictureBox1.Click += (_, _) =>
                {
                    if (progressBar1.Value < progressBar1.Maximum - 14)
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X + 13, pictureBox1.Location.Y);
                        progressBar1.Value += 13;
                    }
                };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 7, pictureBox1.Location.Y);
            progressBar1.PerformStep();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Form1 mainForm = new();
                mainForm.Show();
            }
        }
    }
}
