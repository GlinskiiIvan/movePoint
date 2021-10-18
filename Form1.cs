using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movePoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            Brush brush = new SolidBrush(Color.Blue);            

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            int sizePoint = 10;

            int posX = 0;
            int posY = 1;

            int directionX = -1;
            int directionY = 0;

            while (true)
            {
                if (posX >= width - sizePoint || posX <= 0)
                {
                    directionX = -directionX;
                    directionY = rand.Next(1, 4);
                }

                if ((posY >= height - sizePoint) || (posY <= 0)) directionY = -directionY;

                await Task.Delay(10);
                graphics.Clear(Color.White);
                graphics.FillEllipse(brush, posX, posY, sizePoint, sizePoint);
                posX += directionX;
                posY += directionY;
            }
        }
    }
}
