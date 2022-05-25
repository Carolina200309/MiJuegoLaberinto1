using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace JuegoLaberinto
{
    class Heart: Sprite
    {
        public Heart(Point location) : base("corazon", location, new Point(50,50))
        {

        }
    }
}

