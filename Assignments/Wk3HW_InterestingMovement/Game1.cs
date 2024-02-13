using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;

namespace Wk3HW_InterestingMovement
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        PacManRepo repo;
        PacMan pac;

        SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            repo = new PacManRepo();
            pac = new PacMan(this);

            repo.AddPacMan(pac);

            font = Content.Load<SpriteFont>("MyFont");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            pac.LoadContent(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //Credit: Jeff Meyers
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            pac.UpdatePacManMove(time);
            pac.UpdateInputFromKeyboard();
            pac.UpdatePacManState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            pac.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Hold SPACEBAR to Roll\nHold Left SHIFT to run",new Vector2(10,50),Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}