using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2D_Race
{
    internal class Ball
    {
        //ints used for defining ball x and y
        public int x, y;
        //ball size
        public int size = 8;
        //ball speed
        public int xSpeed, ySpeed;

        //defining ball x, y and xspeed, yspeed
        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move()
        {
            //move balls from left to right
            x += xSpeed;
        }
    }
}
