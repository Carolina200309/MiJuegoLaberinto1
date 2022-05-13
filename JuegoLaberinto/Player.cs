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
        public Player() : base("Daisy", new Point(-40, 450), new Point(120, 120))
        {

        }

        /// <summary>
        /// Move the object horizontally and vertically
        /// /// </summary>
        /// <param name="direction">Enum, that defines string, right, left, down and up</param>

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    this.Location = new Point(this.Location.X + 5, this.Location.Y);

                    break;
                case Direction.Left:
                    this.Location = new Point(this.Location.X - 5, this.Location.Y);
                    break;
                case Direction.Down:
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    break;
                case Direction.Up:
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    break;
                default:
                    break;

            }
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


