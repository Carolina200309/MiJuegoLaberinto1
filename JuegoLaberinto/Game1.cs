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
        
        Player Daisy;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            Daisy = new Player();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
           
            Daisy.LoadContent(this.Content);
            

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

            
            Daisy.Draw(this._spriteBatch, Color.White);
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}