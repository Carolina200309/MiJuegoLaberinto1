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
        /// <param name="direction">string, right, left, down and up</param>

        public void Move(string direction)
        {
            switch (direction)
            {
                case "right":
                    this.Location = new Point(this.Location.X + 5, this.Location.Y);
                    break;
                case "left":
                    this.Location = new Point(this.Location.X - 5, this.Location.Y);
                    break;
                case "down":
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                    break;
                case "up":
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                    break;

            }

        }
    }
}
