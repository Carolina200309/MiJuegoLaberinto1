﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoLaberinto
{
    class Player : Sprite
    {
        public Player() : base("Daisy", new Point(-30, 460), new Point(90, 90))
        {

        }

        /// <summary>
        /// Move the object horizontally and vertically
        /// /// </summary>
        /// <param name="direction">Enum, that defines string, right, left, down and up</param>

        public void Move(Direction direction)
        {
            Rectangle tempLocation = this.rectangle;
            switch (direction)
            {
                case Direction.Right:
                    tempLocation.Location = new Point(this.Location.X + 5, this.Location.Y);

                    break;
                case Direction.Left:
                    tempLocation.Location = new Point(this.Location.X - 5, this.Location.Y);
                    break;
                case Direction.Down:
                    tempLocation.Location = new Point(this.Location.X, this.Location.Y + 5);
                    break;
                case Direction.Up:
                    tempLocation.Location = new Point(this.Location.X, this.Location.Y - 5);
                    break;
                default:
                    break;

            }
            foreach(var item in Walls.walls)
            {
               if(tempLocation.Intersects(item.rectangle))
                {
                    return;
                }
            }
             this.Location = tempLocation.Location;
        }
        }
    enum Direction
    {
        Right,
        Left,
        Up,
        Down

    }
}


