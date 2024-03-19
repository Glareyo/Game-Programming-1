using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
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

        BlockManager blockManager;
        PowerupManager powerupManager;

        GameConsole console;

        public GameHandler(Game game) : base(game)
        {
            console = (GameConsole)this.Game.Services.GetService<IGameConsole>();
            if (console == null)
            {
                console = new GameConsole(this.Game);
                Game.Components.Add(console);
            }
        }

        public override void Initialize()
        {
            ball = new Ball(Game);
            paddle = new Paddle(Game, ball);
            paddleController = new PaddleController(Game, ball);
            blockManager = new BlockManager(Game);
            powerupManager = new PowerupManager(Game);

            Game.Components.Add(ball);
            Game.Components.Add(paddle);
            Game.Components.Add(blockManager);
            Game.Components.Add(powerupManager);

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
            foreach (Invader block in blockManager.Invaders)
            {
                if (ball.Intersects(block) && block.BlockState != BlockState.Broken)
                {
                    blockManager.BlockIsHit(block);
                    ball.Direction.Y *= -1;
                }
            }
            foreach (Powerup power in powerupManager.Powerups)
            {
                if (ball.Intersects(power) && power.State == PowerUpState.Idle)
                {
                    console.GameConsoleWrite($"Powerup Hit");
                    powerupManager.PowerupIsHit(power);
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
