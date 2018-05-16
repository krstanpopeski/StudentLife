using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLife.Properties;

namespace StudentLife
{
    class Grade
    {
        public int X { get; set; }
        public int Y { get; set; }
        private static Random randInt = new Random();
        private Rectangle rectangle;
        public int value;
        public int velocity { get; set; }

        public Grade(int x, int y)
        {
            X = x;
            Y = y;
            rectangle = new Rectangle(0,0,0,0);
            velocity = randInt.Next(3, 12);
            value = randInt.Next(6, 11);
        }


        public void Draw(Graphics g)
        {
            var gradeImage = Resources.eden;


                        if (value == 6)
                        {
                            gradeImage = Resources.sest;
                            rectangle = new Rectangle(X + 300, Y + 225, 67, 109);
            
                        }
                        else if (value == 7)
                        {
                            gradeImage = Resources.sedum;
                            rectangle = new Rectangle(X+305, Y+225, 68, 121);
                        }
                        else if (value == 8)
                        {
                            gradeImage = Resources.osum;
                             rectangle = new Rectangle(X+300, Y+225, 64, 109);
                        }
                        else if (value == 9)
                        {
                            gradeImage = Resources.devet;
                            rectangle = new Rectangle(X+310, Y+225, 62, 112);
                        }
                        else
                        {
                            gradeImage = Resources.deset;
                            rectangle = new Rectangle(X+120, Y+85, 50, 50);
                        }

            g.DrawImage(gradeImage, X,Y );
            
        }

        public bool CheckHitWithMouse(int x, int y)
        {
            return rectangle.IntersectsWith(new Rectangle(x, y, Cursor.Current.Size.Width, Cursor.Current.Size.Height));

        }

        public void Move()
        {
            Y += velocity;
        }
    }
}
