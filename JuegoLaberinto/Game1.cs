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
        Walls walls;
        SpriteFont generalfont;
        int life;
        

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
            walls = new Walls();
            walls.HorizontalWall(new Point(70, 80), 16);
            walls.VerticalWall(new Point(70, 100), 2);
            walls.HorizontalWall(new Point(70, 150), 16);
            walls.VerticalWall(new Point(700, 300), 3);
            walls.HorizontalWall(new Point(-50, 300), 17);
            walls.HorizontalWall(new Point(-20,400), 17);
            walls.HorizontalWall(new Point(1, 550), 18);
            life = 10;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo.LoadContent(this.Content);
            Daisy.LoadContent(this.Content);
            Luigi.LoadContent(this.Content);
            generalfont = this.Content.Load<SpriteFont>("MyFont");

            walls.LoadContent(this.Content);
        

        }
        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState myKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here

            if (myKeyboard.IsKeyDown(Keys.Left))
            {
                Daisy.Move(Direction.Left);
            }
            else if (myKeyboard.IsKeyDown(Keys.Right))
            {
                Daisy.Move(Direction.Right);
            }
            else if (myKeyboard.IsKeyDown(Keys.Down))
            {
                Daisy.Move(Direction.Down);
            }
            else if (myKeyboard.IsKeyDown(Keys.Up))
            {
                Daisy.Move(Direction.Up);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            fondo.Draw(this._spriteBatch, Color.White);

            walls.Draw(this._spriteBatch);
            Daisy.Draw(this._spriteBatch, Color.White);
            Luigi.Draw(this._spriteBatch, Color.White);
            _spriteBatch.DrawString(generalfont, "Lives: " + life.ToString(), new Vector2(200, 5), Color.Black);
            _spriteBatch.DrawString(generalfont, "Time: " + (int)(gameTime.TotalGameTime.TotalSeconds), new Vector2(400, 5), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}