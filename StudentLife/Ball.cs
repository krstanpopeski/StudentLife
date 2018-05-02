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
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public float Velocity { get; set; }
        public float Angle { get; set; }
        public static Rectangle bounds = new Rectangle(1, 41, 745, 426);
        public float velocityX { get; set; }
        public float velocityY { get; set; }

        public Ball(float x, float y, float radius, float velocity,float angle)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;   
            this.Velocity = velocity;
            this.Angle = angle;
            this.velocityX = (float)Math.Cos(Angle) * Velocity;
            this.velocityY = (float)Math.Sin(Angle) * Velocity;

        }

        public void Move()
        {
            float nextX = X + velocityX;
            float nextY = Y + velocityY;
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
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }


    }
}
