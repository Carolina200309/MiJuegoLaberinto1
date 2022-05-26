using System;
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
        
        public Player() : base("Daisy", new Point(5, 460), new Point(85, 85))
        {

        }

        /// <summary>
        /// Move the object horizontally and vertically
        /// /// </summary>
        /// <param name="direction">Enum, that defines string, right, left, down and up</param>
        /// 
        public int countheart = 0;

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

            if (tempLocation.X >= 700 || tempLocation.X <= 0)
            {
                return;
            }
            if (tempLocation.Y >= 500 || tempLocation.Y <= 0)
            {
                return;
            }

            foreach (var item in Walls.walls)
            {
               if(tempLocation.Intersects(item.rectangle))
                {
                    return;
                }
            }

            for (int i = 0; i < Hearts.hearts.Count; i++)
            {
               
               Heart item = Hearts.hearts[i];
                if (tempLocation.Intersects(item.rectangle))
                {
                    Hearts.hearts.RemoveAt(i);
                    countheart++;
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


