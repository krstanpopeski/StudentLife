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
        Graphics graphics;
        Brush brush;
        Pen pen;
        Bitmap doubleBuffer;
        Random randInt;
        private Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game(Width,Height);
            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            randInt = new Random();
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
            game.CheckHit();
            game.Draw(g,brush);
            game.Move();
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);

        }
  

       

    }
}
