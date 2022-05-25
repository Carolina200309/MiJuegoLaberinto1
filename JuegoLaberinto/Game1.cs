using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using System.Collections.Generic;

namespace JuegoLaberinto
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SoundEffectInstance _EffectInstance;
        private SpriteBatch _spriteBatch;
        Background fondo;
        Player Daisy;
        Sprite Luigi;
        Gameover Gameover;
        Walls walls;
        Hearts hearts;
        Song musicajuego;
        SoundEffect completacionnivel;
        SoundEffect perdionivel;
        //Sprite cuadro;
        
        SpriteFont generalfont;
        bool Isgameover;



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
            //cuadro = new Sprite("cuadro", new Point(0,0), new Point(800, 600));
            Gameover = new Gameover();
            Daisy = new Player();
            Luigi = new Sprite("Luigi", new Point(690, 10), new Point(80, 80));
            Isgameover = false;
            walls = new Walls();
            hearts = new Hearts();
            hearts.AddHeart(new Point(100, 470));
            hearts.AddHeart(new Point(500, 470));
            hearts.AddHeart(new Point(710, 350));
            hearts.AddHeart(new Point(500, 230));
            hearts.AddHeart(new Point(20, 230));
            hearts.AddHeart(new Point(600, 20));
            hearts.AddHeart(new Point(200, 20));
            walls.HorizontalWall(new Point(90, 90), 16);
            walls.VerticalWall(new Point(90, 110), 2);
            walls.HorizontalWall(new Point(90, 160), 16);
            walls.VerticalWall(new Point(650, 300), 3);
            walls.HorizontalWall(new Point(-40, 300), 16);
            walls.HorizontalWall(new Point(-25,400), 16);
            walls.HorizontalWall(new Point(1, 550), 18);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            fondo.LoadContent(this.Content);
            Gameover.LoadContent(this.Content);
            Daisy.LoadContent(this.Content);
            Luigi.LoadContent(this.Content);
            generalfont = this.Content.Load<SpriteFont>("MyFont");
            //cuadro.LoadContent(this.Content);
            musicajuego = this.Content.Load<Song>("musicajuego");
            completacionnivel = this.Content.Load<SoundEffect>("completacionnivel");
            perdionivel = this.Content.Load<SoundEffect>("perdionivel");
            MediaPlayer.Play(musicajuego);
            MediaPlayer.Volume = 0.4f;
            walls.LoadContent(this.Content);
            hearts.LoadContent(this.Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState myKeyboard = Keyboard.GetState();

            // TODO: Add your update logic here
            if (!Isgameover)
            {
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
            }
             
             if (Luigi.rectangle.Intersects(Daisy.rectangle))
            {
                MediaPlayer.Pause();
                Luigi.Location = new Point(1000, 1000);
                Isgameover = true;
                completacionnivel.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            fondo.Draw(this._spriteBatch, Color.White);
            //cuadro.Draw(this._spriteBatch, Color.White);
            walls.Draw(this._spriteBatch);
            Daisy.Draw(this._spriteBatch, Color.White);
            Luigi.Draw(this._spriteBatch, Color.White);
            hearts.Draw(this._spriteBatch);

            int tiempo = 12;
            tiempo = tiempo - (int)(gameTime.TotalGameTime.TotalSeconds);
            if(tiempo != 0)
             {   
                _spriteBatch.DrawString(generalfont, "Time: " + tiempo, new Vector2(350, 5), Color.Black);
             }

            else if (tiempo<=0)
            {
                MediaPlayer.Pause();
                if (Isgameover == false) 
                {
                    perdionivel.Play();
                    Isgameover = true;
                }
                    
                Daisy.Location = new Point(2000, 2000);
                Gameover.Draw(this._spriteBatch, Color.White);
            }

            if (Isgameover)
            {
               Gameover.Draw(this._spriteBatch, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}