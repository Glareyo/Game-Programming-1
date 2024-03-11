using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class GameHandler : GameComponent
    {
        Ball ball;
        Paddle paddle;
        PaddleController paddleController;

        List<MonogameBlock> blocks;
        MonogameBlock block;

        public GameHandler(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            blocks = new List<MonogameBlock>();
            
            ball = new Ball(Game);
            paddle = new Paddle(Game, ball);
            paddleController = new PaddleController(Game, ball);
            block = new MonogameBlock(Game);

            blocks.Add(block);

            Game.Components.Add(ball);
            Game.Components.Add(paddle);
            Game.Components.Add(block);

            Viewport vp = Game.GraphicsDevice.Viewport;
            block.Location = new Vector2(vp.Width / 2, vp.Height / 2);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            paddleController.HandleInput(gameTime);
            CheckForBallCollision();

            base.Update(gameTime);
        }

        void CheckForBallCollision()
        {
            foreach(MonogameBlock block in blocks)
            {
                if (ball.Intersects(block))
                {
                    block.Hit();
                    ball.Direction.Y *= -1;
                }
            }
            if (ball.Intersects(paddle))
            {
                ball.Direction.Y *= -1;
            }
        }
    }
}
