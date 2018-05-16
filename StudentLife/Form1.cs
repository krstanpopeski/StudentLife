using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLife.Properties;

namespace StudentLife
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        private int timeCall;
        Brush brush;
        Pen pen;
        Random randInt;
        private Game game;

        public Form1()
        {
            this.Cursor = new Cursor(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\stickman.cur");
            timeCall = 0;
            this.DoubleBuffered = true;
            InitializeComponent();
            game = new Game(Width, Height);
            graphics = CreateGraphics();
            randInt = new Random();
            Show();
            brush = new SolidBrush(Color.Aqua);
            pen = new Pen(Color.Red);
            timer1.Interval = 1000 / 60;
            timer1.Start();
            timer2.Start();
            
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeCall == 100)
            {
                game.generateGrade();
                timeCall = 0;
            }
            game.CheckHit();
            game.Move();
            timeCall++;
            Invalidate(true);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics,new SolidBrush(Color.Blue));
            
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CheckHitWithMouse(e.X, e.Y))
            {
                game = new Game(Width, Height);
                
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!txtName.Text.Equals(""))
            {
                btnNewGame.Enabled = true;
            }
            else
            {
                btnNewGame.Enabled = false;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Paint(object sender, PaintEventArgs e)
        {
            toolStripLabel1.Text = "Points: " + game.poeni;
           TimeSpan t = TimeSpan.FromSeconds(game.vreme);
            string time = string.Format("{0}m:{1}s", t.Minutes, t.Seconds);
           toolStripLabel2.Text = "Time: " + time;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            game.vreme++;
        }
    }
}
