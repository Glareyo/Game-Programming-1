using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;

namespace Week2Demo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont myFont;
        Texture2D pacman;
        Vector2 pacLocation; //X,y Location
        Vector2 pacDirection; //Direction pacman is going
        float pacSpeed; //How fast the pacman goes in a direction. Magnitude.


        //*************************************************
        SpriteFont myCustomFont;
        Texture2D mySprite;
        Vector2 mySpriteLocation; //X,y Location
        Vector2 mySpriteDirection; //Direction pacman is going
        //*************************************************



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            /*_graphics.PreferredBackBufferHeight = 0;
            _graphics.PreferredBackBufferWidth = 0;
            _graphics.IsFullScreen = true;*/
            Content.RootDirectory = "Content";


            TargetElapsedTime = TimeSpan.FromTicks(333333);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacman = Content.Load<Texture2D>("PacmanSingle");
            pacLocation = new Vector2(100, 150);
            pacDirection = new Vector2(1, 1);

            //Before, used to be 100 pixels per call
            pacSpeed = 200;
            
            
            myFont = Content.Load<SpriteFont>("MyCustomFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdatePacmanMove(gameTime);
            UpdatePacmanKeepOnScreen();





            base.Update(gameTime);
        }
        void UpdatePacmanMove(GameTime gameTime)
        {
            //Incorrect Use
            //pacLocation += (pacDirection * pacSpeed);

            //Time corrected movement, changing from pixels per update to per second.
            pacLocation += (pacDirection * pacSpeed) * ((float)gameTime.ElapsedGameTime.TotalMilliseconds/1000);
        }

        void UpdatePacmanKeepOnScreen()
        {
            //Turn around if reaching the end of the viewport
            // pacman's x location + pacman's sprite width
            if ((this.pacLocation.X + pacman.Width > GraphicsDevice.Viewport.Width
                || this.pacLocation.X < 0
                ))
            {
                pacDirection.X *= -1;
            }

            if (this.pacLocation.Y + pacman.Height > GraphicsDevice.Viewport.Height
                || this.pacLocation.Y < 0)
            {
                pacDirection.Y *= -1;
            }
            //Move pacman to other side of screen
            // pacman's x location + pacman's sprite width
            /*if (this.pacLocation.X > GraphicsDevice.Viewport.Width)
            {
                pacLocation.X -= GraphicsDevice.Viewport.Width + pacman.Width;
            }*/


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Do not do anything else in Draw except DRAW
            _spriteBatch.Begin();
            _spriteBatch.Draw(pacman, pacLocation, Color.White);
            _spriteBatch.DrawString(myFont, "pacLocation" + pacLocation.ToString(), new Vector2(100, 100), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
