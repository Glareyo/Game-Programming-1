    using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Picture
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        /// CUSTOM Contnet
        //*******************************************************************************
        //*******************************************************************************
        //*******************************************************************************
        
        public SpriteFont customFont;
        public Texture2D smallFire;
        public Texture2D largeFire;
        public Texture2D cpuBox;
        public Texture2D computer;

        //*******************************************************************************
        //*******************************************************************************
        //*******************************************************************************




        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            customFont = Content.Load<SpriteFont>("CustomFont2");

            smallFire = Content.Load<Texture2D>("Images/smallFire");
            largeFire = Content.Load<Texture2D>("Images/largeFire");
            cpuBox = Content.Load<Texture2D>("Images/database");
            computer = Content.Load<Texture2D>("Images/computer");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draw strings with some extra shadows
            _spriteBatch.DrawString(customFont, "Programming is Fun!", new Vector2(102, 80), Color.Black);
            
            _spriteBatch.Draw(cpuBox, new Vector2(250, 151), Color.White);
            _spriteBatch.Draw(computer, new Vector2(390, 200), Color.White);

            _spriteBatch.Draw(smallFire, new Vector2(250, 300), Color.White);
            _spriteBatch.Draw(largeFire, new Vector2(390, 200), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}