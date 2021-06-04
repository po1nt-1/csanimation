using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace csanimation
{
    public partial class Form1 : Form
    {
        bool animationEnabled = false;
        int startX, endX, startY, endY;
        double betta;
        Graphics graph;

        Random rnd = new();

        int h;
        int v;
        int dir;


        public Form1()
        {
            InitializeComponent();
            Program.f1 = this;

            graph = pictureBox1.CreateGraphics();
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
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (animationEnabled)
            {
                int shir = endX - 1;
                Point[] curve1 = new Point[2 * shir];
                Point[] curve2 = new Point[2 * shir];
                Point[] curve3 = new Point[2 * shir];
                Point[] curve4 = new Point[2 * shir];
                Point[] curve5 = new Point[2 * shir];
                int total = 5;
                double alpha = 0;

                int x = h + startX;
                int y = v + startY;

                if (x + endX >= pictureBox1.Size.Width)
                {
                    h -= 5;
                    dir = rnd.Next(1, 9);
                }
                if (x <= 0)
                {
                    h += 5;
                    dir = rnd.Next(1, 9);
                }
                if (y + endY >= pictureBox1.Size.Height)
                {
                    v -= 5;
                    dir = rnd.Next(1, 9);
                }
                if (y <= 0)
                {
                    v += 5;
                    dir = rnd.Next(1, 9);
                }

                for (int i = 0; i < endX; i++)
                {
                    alpha += 2.0 * Math.PI / shir;
                    curve1[i].X = x + i;
                    curve1[i].Y = v + (int)(startY + (endY - startY) / 10 * Math.Sin(alpha + betta));
                    curve1[2 * shir - 1 - i].X = x + i;
                    curve1[2 * shir - 1 - i].Y = curve1[i].Y + (endY - startY) / total;

                    curve2[i].X = x + i;
                    curve2[i].Y = curve1[2 * shir - 1 - i].Y;
                    curve2[2 * shir - 1 - i].X = x + i;
                    curve2[2 * shir - 1 - i].Y = curve2[i].Y + (endY - startY) / total;

                    curve3[i].X = x + i;
                    curve3[i].Y = curve2[2 * shir - 1 - i].Y;
                    curve3[2 * shir - 1 - i].X = x + i;
                    curve3[2 * shir - 1 - i].Y = curve3[i].Y + (endY - startY) / total;

                    curve4[i].X = x + i;
                    curve4[i].Y = curve3[2 * shir - 1 - i].Y;
                    curve4[2 * shir - 1 - i].X = x + i;
                    curve4[2 * shir - 1 - i].Y = curve4[i].Y + (endY - startY) / total;

                    curve5[i].X = x + i;
                    curve5[i].Y = curve4[2 * shir - 1 - i].Y;
                    curve5[2 * shir - 1 - i].X = x + i;
                    curve5[2 * shir - 1 - i].Y = curve5[i].Y + (endY - startY) / total;
                }
                graph.Clear(pictureBox1.BackColor);
                graph.FillPolygon(new SolidBrush(Color.Green), curve1);
                graph.FillPolygon(new SolidBrush(Color.White), curve2);
                graph.FillPolygon(new SolidBrush(Color.Blue), curve3);
                graph.FillPolygon(new SolidBrush(Color.Orange), curve4);
                graph.FillPolygon(new SolidBrush(Color.Red), curve5);
                betta += (Math.PI / 18);

                if (dir == 4)
                    h += 4;
                else if (dir == 8)
                    h -= 4;
                else if (dir == 6)
                    v += 6;
                else if (dir == 2)
                    v -= 6;
                else if (dir == 5)
                {
                    h += 4;
                    v += 4;
                }
                else if (dir == 3)
                {
                    h += 4;
                    v -= 4;
                }
                else if (dir == 7)
                {
                    h -= 4;
                    v += 4;
                }
                else if (dir == 1)
                {
                    h -= 4;
                    v -= 4;
                }

            }
            this.Text = $"X1={Convert.ToString(startX)}, X1={Convert.ToString(startY)}, X2={Convert.ToString(endX)}, X2={Convert.ToString(endY)}, ширина: {endX - startX}";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            h = 0;
            v = 0;
            dir = rnd.Next(1, 5);
            betta = 0;
            startX = e.X;
            startY = e.Y;
            timer1.Stop();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startX < e.X)
            {
                endX = e.X;
            }
            else
            {
                endX = startX;
                startX = e.X;
            }
            if (startY < e.Y)
            {
                endY = e.Y;
            }
            else
            {
                endY = startY;
                startY = e.Y;
            }

            if (startX < 0)
                startX = 1;
            if (startY < 0)
                startY = 1;
            
            if (endX > pictureBox1.Size.Width)
                endX = pictureBox1.Size.Width - 1;
            if (endY > pictureBox1.Size.Height)
                endY = pictureBox1.Size.Height - 1;

            timer1.Start();
            this.Text = $"X1={Convert.ToString(startX)}, X1={Convert.ToString(startY)}, X2={Convert.ToString(endX)}, X2={Convert.ToString(endY)}";
        }

    }

}
