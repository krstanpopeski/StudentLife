using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLife.Properties;

namespace StudentLife
{
    [Serializable]
    public partial class Form1 : Form
    {
        Graphics graphics;
        private int timeCall;
        Brush brush;
        Pen pen;
        private string FileName;
        public bool isPaused;
        Random randInt;
        private Game game;

        public Form1()
        {
            isPaused = false;
            this.Cursor = new Cursor(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\stickman.cur");
            timeCall = 0;
            FileName = null;
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
            game = new Game(Width, Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
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

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!isPaused)
            {
                game.Draw(e.Graphics, new SolidBrush(Color.Blue));
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CheckHitWithMouse(e.X, e.Y))
            {
                game = new Game(Width, Height);
                isPaused = false;
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
            toolStripLabel3.Text = "Level: " + game.level;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                game.vreme++;
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            if (FileName == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                isPaused = true;
                dialog.Filter = "Student's Life | *.stlf";
                dialog.Title = "Save your game";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName;
                }
            }

            try
            {
                FileStream stream = new FileStream(FileName, FileMode.Create);
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, (Game) game);
                isPaused = false;
                FileName = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving file! "+ ex.Message);
                isPaused = false;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                isPaused = false;
                btnPause.Text = "Pause";
            }
            else
            {
                isPaused = true;
                btnPause.Text = "Continue";
            }
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            if (FileName == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                isPaused = true;
                dialog.Filter = "Student's Life | *.stlf";
                dialog.Title = "Open your saved game!";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName;
                }
            }

            try
            {
                FileStream stream = new FileStream(FileName, FileMode.Open);
                var formatter = new BinaryFormatter();
                game = (Game) formatter.Deserialize(stream);
                FileName = null;
                isPaused = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening file!");
                isPaused = false;
            }

        }
    }
}
