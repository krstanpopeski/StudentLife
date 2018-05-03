using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLife
{
    class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }
        public static Rectangle bounds = new Rectangle(1, 41, 745, 426);
        public double velocityX { get; set; }
        public double velocityY { get; set; }

        public double mass = 1;

        public Ball(double x, double y, double radius, double velocity,double angle)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;   
            this.Velocity = velocity;
            this.Angle = angle;
            this.velocityX = Math.Cos(Angle) * Velocity;
            this.velocityY = Math.Sin(Angle) * Velocity;

        }

        public void Move()
        {
            double nextX = X + velocityX;
            double nextY = Y + velocityY;
            if(nextX - Radius <= bounds.Left || (nextX + Radius >= bounds.Right))
            {
                velocityX = -velocityX;

            }
            if(nextY - Radius <= bounds.Top || (nextY - Radius >= bounds.Bottom))
            {
                velocityY = -velocityY;
            }
            X += velocityX;
            Y += velocityY;
        }

        public void Draw(Brush brush, Graphics g)
        {
            g.FillEllipse(brush, (float)(X - Radius), (float)(Y - Radius), (float)(Radius * 2), (float)(Radius * 2));
        }


    }
}
