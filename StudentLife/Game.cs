using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLife
{
    class Game
    {
        public List<Ball> balls { get; set; }
        public static Random randInt = new Random();
        public int Width { get; set; }
        public int Height { get; set; }
        public Grade grade;
        public int poeni { get; set; }
        public int vreme { get; set; }
        public Game(int Width, int Height)
        {
            vreme = 0;
            balls = new List<Ball>();
            for (int i = 0; i < 10; i++)
            {
               Ball ball = new Ball((float)randInt.Next(0, Width), (float)randInt.Next(41, Height), 20, randomDx(), randomDy());
                balls.Add(ball);
            }
            grade = new Grade(randInt.Next(-290, 560),-270);
            poeni = 0;
        }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public void generateGrade()
        {
            grade = new Grade(randInt.Next(-290, 560), -270);
        }

        public void CheckHit()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = 0; j < balls.Count; j++)
                {
                    if (j != i && distanceNextFrame(balls.ElementAt(i), balls.ElementAt(j)) <= 0)
                    {
                        var d = Math.Sqrt(Math.Pow(balls.ElementAt(j).X - balls.ElementAt(i).X, 2)
                                          + Math.Pow(balls.ElementAt(j).Y - balls.ElementAt(i).Y, 2));

                        if (balls.ElementAt(i).Radius + balls.ElementAt(i).Radius >= d)
                        {
                            var ball1 = balls.ElementAt(i);
                            var ball2 = balls.ElementAt(j);
                            ManageBounce(ball1, ball2);

                        }
                    }
                }
            }
        }

        public bool CheckHitWithMouse(int x, int y)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                
                var d = Math.Sqrt(Math.Pow(x - balls.ElementAt(i).X, 2)
                          + Math.Pow(y - balls.ElementAt(i).Y, 2));

                 if (balls.ElementAt(i).Radius + balls.ElementAt(i).Radius >= d)
                 {
                     MessageBox.Show("Game Over! You have won: "+poeni+" points!");
                     return true;

                 }
                 
                
            } 

            if (grade.CheckHitWithMouse(x, y))
            {
                poeni += grade.value;
                generateGrade();
            }

            return false;
        }

        public void Draw(Graphics g, Brush b)
        {
            foreach (Ball ball in balls)
            {
                ball.Draw(b,g);
            }
            grade.Draw(g);
        }

        public void Move()
        {
            foreach (Ball ball in balls)
            {
                ball.Move();;
            }
            grade.Move();
        }

        private void ManageBounce(Ball ball1, Ball ball2)
        {
            var dx = ball2.X - ball1.X;
            var dy = ball2.Y - ball1.Y;
            var phi = Math.Atan2(dy, dx);
            var theta1 = Math.Atan2(ball1.velocityY, ball1.velocityX);
            var theta2 = Math.Atan2(ball2.velocityY, ball2.velocityX);
            var v1 = ball1.Velocity;
            var v2 = ball2.Velocity;
            var m1 = ball1.mass;
            var m2 = ball2.mass;

            var dx1F = (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) *
                       Math.Cos(phi) + v1 * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2);
            var dy1F = (v1 * Math.Cos(theta1 - phi) * (m1 - m2) + 2 * m2 * v2 * Math.Cos(theta2 - phi)) / (m1 + m2) *
                       Math.Sin(phi) + v1 * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2);
            var dx2F = (v2 * Math.Cos(theta2 - phi) * (m2 - m1) + 2 * m1 * v1 * Math.Cos(theta1 - phi)) / (m1 + m2) *
                       Math.Cos(phi) + v2 * Math.Sin(theta2 - phi) * Math.Cos(phi + Math.PI / 2);
            var dy2F = (v2 * Math.Cos(theta2 - phi) * (m2 - m1) + 2 * m1 * v1 * Math.Cos(theta1 - phi)) / (m1 + m2) *
                       Math.Sin(phi) + v2 * Math.Sin(theta2 - phi) * Math.Sin(phi + Math.PI / 2);

            ball1.velocityX = dx1F;
            ball1.velocityY = dy1F;
            ball2.velocityX = dx2F;
            ball2.velocityY = dy2F;
        }

        private void moveMan(int x, int y,Graphics g)
        {

        }


        private double distanceNextFrame(Ball ball1, Ball ball2)
        {
            return Math.Sqrt(Math.Pow(ball1.X + ball1.velocityX - ball2.X - ball2.velocityX, 2)
                             + Math.Pow(ball1.Y + ball1.velocityY - ball2.Y - ball2.velocityY, 2)) - ball1.Radius -
                   ball2.Radius;
        }



        private double randomDx()
        {
            var r = Math.Floor((double)randInt.Next(0, 1) * 10 - 5);
            return r;
        }

        private double randomDy()
        {
            var re = Math.Floor((double)randInt.Next(0, 1) * 10 - 5);
            return re;
        }
    }

}
