using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLife
{
    public partial class Form1 : Form
    {
        Ball ball;
        Graphics graphics;
        Brush brush;
        Pen pen;
        Bitmap doubleBuffer;

        public Form1()
        {
            InitializeComponent();
            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            Random randInt = new Random();
            ball = new Ball((float)randInt.Next(0, Width), (float)randInt.Next(41, Height), 20, 10, (float)(Math.PI / randInt.Next(-20, 20)));
            Show();
            brush = new SolidBrush(Color.Aqua);
            pen = new Pen(Color.Red);
            timer1.Interval = 1000 / 60;
            timer1.Start();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.White);
            g.DrawRectangle(pen, Ball.bounds);
            ball.Draw(brush, g);
            ball.Move();
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);

        }
    }
}
