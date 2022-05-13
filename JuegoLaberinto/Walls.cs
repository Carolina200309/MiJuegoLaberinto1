using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoLaberinto
{
    class Walls
    {
        List<Wall> walls;

        public Walls()
        {
            walls = new List<Wall>();
        }

        public void LoadContent(ContentManager cm)
        {
            foreach (var item in walls)
            {
                item.LoadContent(cm);
            }
        }

        public void HorizontalWall(Point location, int numveces)
        {
        //    int tempx = location.X;
        //    for (int i = 0; i < numveces; i++)
        //    {
        //        horizontals.Add(new Wall(new Point(45, 45), new Point(tempx, location.Y)));
        //        tempx += 45;
        //    }
            AddWall(location.X, location.Y, numveces, true);
        }

        public void VerticalWall(Point location, int numveces)
        {
            //         int tempy = location.Y;
            //         for (int i = 0; i<numveces; i++)
            //{
            //             verticals.Add(new Wall(new Point(45, 45), new Point(location.X, tempy)));
            //             tempy += 45;
            //}
            AddWall(location.X, location.Y, numveces, false);
        }

        private void AddWall(int x, int y, int numveces, bool isHorizontal)
        {
            for (int i = 0; i < numveces; i++)
            {
                walls.Add(new Wall(new Point(45, 45), new Point(x, y)));
                if (isHorizontal)
                {
                    x += 45;
                }
                else
                {
                    y += 45;
                }
            }
        }

        public void Draw (SpriteBatch sp)
        {
            foreach (var item in walls)
            {
                item.Draw(sp, Color.White);
            }
        }
    }
}
