﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace _2D_Race
{
    internal class Player
    {
        public int x, y;
        public int width = 10;
        public int height = 10;
        public int speed = 6;

        public Player()
        {
            //hero spawn point
            x = 180;
            y = 350;
        }

        public void Move(string direction)
        {
            //ball move up
            if (direction == "up" && y > 0 && GameScreen.keyPressed == false)
            {
                y -= speed;
            }

            //ball move down
            if (direction == "down" && y > 0 && GameScreen.keyPressed == false)
            {
                y += speed;
            }
        }

        public bool Collision(Ball b)
        {
            Rectangle heroRec = new Rectangle(x, y, width, height);
            Rectangle ballRec = new Rectangle(b.x, b.y, b.size, b.size);

            //if hero and ball intersect, reset hero spawn point
            if (heroRec.IntersectsWith(ballRec))
            {
                x = 180;
                y = 350;
                
                SoundPlayer errorSound = new SoundPlayer(Properties.Resources.Error);
                errorSound.Play();
            }

            return false;
        }

        public bool powerUpCollision(Rectangle powerUp)
        {
            Rectangle heroRec = new Rectangle(x, y, width, height);

            //if hero and power up block intersect, increase hero speed
            if (heroRec.IntersectsWith(powerUp))
            {
                speed++;
            }

            return false;
        }

    }
}
