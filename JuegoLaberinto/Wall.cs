using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoLaberinto
{
    class Wall : Sprite
    {
        public Wall(Point size, Point location) : base("Walls", location, size)
        {
            
        }
    }
}
