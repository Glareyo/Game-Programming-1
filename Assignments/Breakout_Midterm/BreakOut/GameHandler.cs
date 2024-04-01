using BreakOut.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut
{
    public class GameHandler : GameComponent
    {
        Ball ball;
        Paddle paddle;
        PaddleController paddleController;

        BlockManager blockManager;
        PowerupManager powerupManager;
        BallManager ballManager;

        ScoreBoard scoreBoard;

        GameConsole console;

        public GameHandler(Game game) : base(game)
        {
            console = (GameConsole)this.Game.Services.GetService<IGameConsole>();
            if (console == null)
            {
                console = new GameConsole(this.Game);
                //Game.Components.Add(console);
            }
        }

        public override void Initialize()
        {
            ball = new Ball(Game);
            paddle = new Paddle(Game, ball);
            paddleController = new PaddleController(Game, ball);
            blockManager = new BlockManager(Game);
            powerupManager = new PowerupManager(Game);
            ballManager = new BallManager(Game,ball);

            scoreBoard = new ScoreBoard(Game);

            Game.Components.Add(ball);
            Game.Components.Add(paddle);
            Game.Components.Add(blockManager);
            Game.Components.Add(powerupManager);
            Game.Components.Add(scoreBoard);

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
            for(int i = 0; i < ballManager.balls.Count; i++)
            {
                ball = ballManager.balls[i];
                foreach (Invader invader in blockManager.Invaders)
                {
                    if (ball.Intersects(invader) && invader.BlockState != BlockState.Broken)
                    {
                        blockManager.BlockIsHit(invader);
                        ball.Direction.Y *= -1;
                        
                        //Updated Scoreboard
                        if (invader.BlockState == BlockState.Broken)
                        {
                            scoreBoard.InvaderDestroyed();
                        }
                    }
                }
                foreach (Powerup power in powerupManager.Powerups)
                {
                    if (ball.Intersects(power) && power.State == PowerUpState.Idle)
                    {
                        powerupManager.PowerupIsHit(power);
                        ballManager.PowerUpBall(ball, power);

                        //Updated Scoreboard
                        scoreBoard.PowerupCollected();
                    }
                }
                if (ball.Intersects(paddle))
                {
                    ball.Direction.Y *= -1;
                }
            }
        }
    }
}
