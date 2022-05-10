using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoLaberinto
{
    class Walls : Sprite
    {
        public Walls(Point size, Point location) : base("Walls", location, size)
        {

        }

        public static List<Walls> HorizontalWall(Point location, int numveces)
        {
            List<Walls> walls = new List<Walls>();
            int tempx = location.X;
            for (int i = 0; i < numveces; i++)
            {
                walls.Add(new Walls(new Point(50, 50), new Point(tempx, location.Y)));
                tempx += 50;
            }

            return walls;
        }

        public static List<Walls> VerticalWall(Point location, int numveces)
        {
            List<Walls> walls = new List<Walls>();
            int tempy = location.Y;
            for (int i = 0; i<numveces; i++)
			{
                walls.Add(new Walls(new Point(50, 50), new Point(location.X, tempy)));
                tempy += 50;
			}

            return walls;
        }
    }
}
