//Credit:
//Jeff Meyers
//Provided classes, codes, and lecture on monogame.
//Class from Jeff Meyers's Examples

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class Ball : DrawableSprite
    {
        public enum BallState { OnPaddleStart,Playing};
        public BallState State;
        GameConsole console;

        public Ball(Game game) : base(game)
        {
            this.State = BallState.OnPaddleStart;

            console = (GameConsole)this.Game.Services.GetService<IGameConsole>();
            if(console == null)
            {
                console = new GameConsole(this.Game);
                Game.Components.Add(console);
                //this.Game.Services.AddService<IGameConsole>(console);
                //this.Game.Services.AddService<console>;
            }

            this.ShowMarkers = true;
        }

        protected override void LoadContent()
        {
            spriteTexture = Game.Content.Load<Texture2D>("ballSmall");
            SetInitialLocation();
            base.LoadContent();
        }

        public void SetInitialLocation()
        {
            this.Location = new Vector2(200, 300);
        }

        public void LaunchBall(GameTime gameTime)
        {
            this.Speed = 190;
            this.Direction = new Vector2(1, -1);
            this.State = BallState.Playing;
            this.console.GameConsoleWrite("Ball Launched " + gameTime.TotalGameTime.ToString());
        }

        private void resetBall(GameTime gameTime)
        {
            this.Speed = 0;
            this.State = BallState.OnPaddleStart;
            this.console.GameConsoleWrite("Ball Reset " + gameTime.TotalGameTime.ToString());
        }

        public override void Update(GameTime gameTime)
        {
            switch (this.State)
            {
                case BallState.OnPaddleStart:
                    break;

                case BallState.Playing:
                    UpdateBall(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        private void UpdateBall(GameTime gameTime)
        {
            this.Location += this.Direction * (this.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000);

            //bounce off wall
            //Left and Right
            if ((this.Location.X + this.spriteTexture.Width > this.Game.GraphicsDevice.Viewport.Width)
                ||
                (this.Location.X < 0))
            {
                this.Direction.X *= -1;
            }
            //bottom Miss
            if (this.Location.Y + this.spriteTexture.Height > this.Game.GraphicsDevice.Viewport.Height)
            {
                this.Direction.Y *= -1;
                console.GameConsoleWrite("Should lose life here!!!");
            }

            //Top
            if (this.Location.Y < 0)
            {
                this.Direction.Y *= -1;
            }
        }
    }
}
