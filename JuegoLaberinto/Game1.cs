using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace JuegoLaberinto
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Background fondo;
        Player Daisy;
        Sprite Luigi;
        List<Walls> walls;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            fondo = new Background();
            Daisy = new Player();
            Luigi = new Sprite("Luigi", new Point(690, 0), new Point(80, 80));
            walls = new List<Walls>();
            walls.AddRange(Walls.HorizontalWall(new Point(70, 80), 16));
            walls.AddRange(Walls.VerticalWall(new Point(70, 100), 2));
            walls.AddRange(Walls.HorizontalWall(new Point(70, 150), 16));
            walls.AddRange(Walls.VerticalWall(new Point(700, 300), 3));
            walls.AddRange(Walls.HorizontalWall(new Point(-50, 300), 17));
            walls.AddRange(Walls.HorizontalWall(new Point(-20,400), 17));
            walls.AddRange(Walls.HorizontalWall(new Point(1, 550), 18));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo.LoadContent(this.Content);
            Daisy.LoadContent(this.Content);
            Luigi.LoadContent(this.Content);

            foreach (var item in walls)
            {
                item.LoadContent(this.Content);
            }
        

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState myKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here

            if (myKeyboard.IsKeyDown(Keys.Left))
            {
                Daisy.Move("left");
            }
            else if (myKeyboard.IsKeyDown(Keys.Right))
            {
                Daisy.Move("right");
            }
            else if (myKeyboard.IsKeyDown(Keys.Down))
            {
                Daisy.Move("down");
            }
            else if (myKeyboard.IsKeyDown(Keys.Up))
            {
                Daisy.Move("up");
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            fondo.Draw(this._spriteBatch, Color.White);
            foreach (var item in walls)
            {
                item.Draw(this._spriteBatch, Color.White);
            }
            Daisy.Draw(this._spriteBatch, Color.White);
            Luigi.Draw(this._spriteBatch, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}