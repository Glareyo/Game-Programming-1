using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Bringing in your own sprite font
        public SpriteFont font;
        // Bring your own texture / image into Game
        public Texture2D pacman;

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
            font = Content.Load<SpriteFont>("Font");
            pacman = Content.Load<Texture2D>("PacmanSingle");
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
            //Call only once
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draw strings with some extra shadows
            _spriteBatch.DrawString(font, "Hello Monogame!!!", new Vector2(102, 102), Color.Black);
            
            //Add shadows to string
            _spriteBatch.DrawString(font, "Hello Monogame!!!", new Vector2(101, 101), Color.DarkGray);
            _spriteBatch.DrawString(font,"Hello Monogame!!!", new Vector2(100,100),Color.Aqua);

            //Draw Pacman
            // Color.White keep the colors of the image the same
            // Changing the color will change the shader color the image is drawn under.
            _spriteBatch.Draw(pacman, new Vector2(200, 200), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
