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
        public static Rectangle bounds { get; set; }
        public double velocityX { get; set; }
        public double velocityY { get; set; }

        public double mass { get; set; }

        public Ball(double x, double y, double radius, double dx, double dy)
        {
            bounds = new Rectangle(1, 41, 745, 400);
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Velocity = Math.Sqrt(dx * dx + dy * dy);
            this.Angle = Math.Atan2(dy, dx);
            this.velocityX = dx;
            this.velocityY = dy;
            this.mass = new Random().NextDouble() * (0.9 - 0.1) + 0.1;

        }

        public void Move()
        {
            double nextX = X + velocityX;
            double nextY = Y + velocityY;
            if (nextX - Radius <= bounds.Left || (nextX + Radius >= bounds.Right))
            {
                velocityX = -velocityX;

            }
            if (nextY - Radius <= bounds.Top || (nextY - Radius >= bounds.Bottom))
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
