using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoLaberinto
{
    class Hearts
    {
        public static List<Heart> hearts;

        public Hearts()
        {
            hearts = new List<Heart>();
        }
        public void LoadContent(ContentManager cm)
        {
           foreach (var item in hearts)
           {
              item.LoadContent(cm);
           }
        }
        public void AddHeart(Point location)
        {
            hearts.Add(new Heart(location));
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (var item in hearts)
            {
                item.Draw(sp, Color.White);
            }
        }

    }
}
