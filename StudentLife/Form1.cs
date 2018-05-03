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
        Random randInt;
        List<Ball> balls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            randInt = new Random();
            for(int i = 0; i < 10; i++)
            {
                ball = new Ball((float)randInt.Next(0, Width), (float)randInt.Next(41, Height), 20, 10, (float)(Math.PI / randInt.Next(-20, 20)));
                balls.Add(ball);
            }
            
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
            for(int i = 0; i < balls.Count; i++)
            {
                for(int j = 0; j < balls.Count; j++)
                {
                    if (j != i)
                    {
                        var d = Math.Sqrt(Math.Pow(balls.ElementAt(j).X - balls.ElementAt(i).X, 2)
                            + Math.Pow(balls.ElementAt(j).Y - balls.ElementAt(i).Y, 2));
                        
                        if(balls.ElementAt(i).Radius + balls.ElementAt(i).Radius >= d)
                        {

                            //ManageBounce(balls.ElementAt(i), balls.ElementAt(j));
                            var ball1 = balls.ElementAt(i);
                            var ball2 = balls.ElementAt(j);
                            ball1.velocityX = ball2.velocityX;
                            ball1.velocityY = ball2.velocityY;

                        }
                    }
                }
            }

            foreach (var ball in balls)
            {
                ball.Draw(brush, g);
                ball.Move();
            }
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);

        }

        private void ManageBounce(Ball ball1, Ball ball2)
        {
            //var dx = ball1.X - ball2.X;
            //var dy = ball1.Y - ball2.Y;
            //var collisionAngle = Math.Atan2(dy, dx);
            //var magnitude1 = Math.Sqrt(ball1.velocityX * ball1.velocityX + ball1.velocityY * ball1.velocityY);
            //var magnitude2 = Math.Sqrt(ball2.velocityX * ball2.velocityX + ball2.velocityY * ball2.velocityY);
            //var direction1 = Math.Atan2(ball1.velocityY, ball1.velocityX);
            //var direction2 = Math.Atan2(ball2.velocityY, ball2.velocityX);
            //var newVelocityX1 = magnitude1 * Math.Cos(direction1 - collisionAngle);
            //var newVelocityY1 = magnitude1 * Math.Sin(direction1 - collisionAngle);
            //var newVelocityX2 = magnitude2 * Math.Cos(direction2 - collisionAngle);
            //var newVelocityY2 = magnitude2 * Math.Sin(direction2 - collisionAngle);
            //var finalVelocityX1 = ((ball1.mass - ball2.mass) * newVelocityX1 + (ball2.mass + ball2.mass) * newVelocityX2) / (ball1.mass + ball2.mass);
            //var finalVelocityX2 = ((ball1.mass + ball1.mass) * newVelocityX1 + (ball2.mass - ball1.mass) * newVelocityX2) / (ball1.mass + ball2.mass);
            //var finalVelocityY1 = newVelocityY1;
            //var finalVelocityY2 = newVelocityY2;
            ////ball1.velocityX = Math.Cos(collisionAngle) * finalVelocityX1 + Math.Cos(collisionAngle + Math.PI / 2) * finalVelocityY1;
            ////ball1.velocityY = Math.Sin(collisionAngle) * finalVelocityX1 + Math.Sin(collisionAngle + Math.PI / 2) * finalVelocityY1;
            ////ball2.velocityX = Math.Cos(collisionAngle) * finalVelocityX2 + Math.Cos(collisionAngle + Math.PI / 2) * finalVelocityY2;
            ////ball2.velocityY = Math.Sin(collisionAngle) * finalVelocityX2 + Math.Cos(collisionAngle + Math.PI / 2) * finalVelocityY2;
            //ball1.velocityX = finalVelocityX1;
            //ball1.velocityY = finalVelocityX2;
            //ball2.velocityX = finalVelocityY1;
            //ball2.velocityY = finalVelocityY2;
            var newVelX1 = (2*ball2.velocityX)
        }
    }
}
