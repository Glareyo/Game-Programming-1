using BreakOut.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut
{
    public enum GamePlayState { Runnning, Disabled }

    /// <summary>
    /// Handles to direct gameplay of the game
    /// </summary>
    public class GamePlayHandler : GameComponent
    {
        List<IGameComponent> GameplayComponents;

        InvaderLevel level;

        Ball ball;
        Paddle paddle;
        PaddleController paddleController;

        InvaderManager invaderManager;
        PowerupManager powerupManager;
        BallManager ballManager;

        ScoreBoard scoreBoard;

        public ScoreBoard GetScoreBoard { get { return scoreBoard; } }

        int numOfSmallInvaders;
        int numOfLargeInvaders;

        public GamePlayState State { get; private set; }

        /// <summary>
        /// Create Gameplay with set enemies
        /// </summary>
        /// <param name="gamem"></param>
        /// <param name="_numOfSmallInvaders">Number of Small Invaders</param>
        /// <param name="_numOfLargeInvaders">Number of Large Invaders</param>
        public GamePlayHandler(Game game, InvaderLevel level, int _numOfSmallInvaders, int _numOfLargeInvaders) : base(game)
        {
            GameplayComponents = new List<IGameComponent>();

            numOfSmallInvaders = _numOfSmallInvaders;
            numOfLargeInvaders = _numOfLargeInvaders;

            this.level = level;

            State = GamePlayState.Runnning;
        }

        public override void Initialize()
        {
            ball = new Ball(Game);
            paddle = new Paddle(Game, ball);
            paddleController = new PaddleController(Game, ball);
            
            //Set InvaderManager with number or invaders
            invaderManager = new InvaderManager(Game,numOfSmallInvaders,numOfLargeInvaders);

            powerupManager = new PowerupManager(Game);
            ballManager = new BallManager(Game,ball);

            scoreBoard = new ScoreBoard(Game, level.Name);



            GameplayComponents.Add(ball);
            GameplayComponents.Add(paddle);
            GameplayComponents.Add(invaderManager);
            GameplayComponents.Add(ballManager);
            GameplayComponents.Add(powerupManager);
            GameplayComponents.Add(scoreBoard);

            AddComponentsToGame();

            base.Initialize();
        }

        public void AddComponentsToGame()
        {
            foreach(IGameComponent component in GameplayComponents) 
            {
                Game.Components.Add(component);
            }
        }
        public void ClearComponents()
        {
            foreach (IGameComponent component in GameplayComponents)
            {
                Game.Components.Remove(component);
            }
        }
        public override void Update(GameTime gameTime)
        {
            paddleController.HandleInput(gameTime);
            CheckForBallCollision();
            //Disable the gameplay if all invaders are destroyed
            if (InvadersDestroyed() || BallsAreDestroyed() || InvaderSucceededPastPlayer())
            {
                this.State = GamePlayState.Disabled;
                ballManager.ClearComponents();
                powerupManager.ClearComponents();
                invaderManager.ClearComponents();
            }

            base.Update(gameTime);
        }

        public bool BallsAreDestroyed()
        {
            if (ballManager.State == BallManagerState.Stopped)
            {
                return true;
            }
            return false;
        }

        public bool InvaderSucceededPastPlayer()
        {
            if (invaderManager.State == InvaderManagerState.InvaderSucceeded)
            {
                return true;
            }
            return false;
        }

        public bool InvadersDestroyed()
        {
            if (invaderManager.State == InvaderManagerState.OutOfInvaders)
            {
                return true;
            }
            return false;
        }
        void CheckForBallCollision()
        {
            for(int i = 0; i < ballManager.balls.Count; i++)
            {
                ball = ballManager.balls[i];
                foreach (Invader invader in invaderManager.Invaders)
                {
                    if (ball.Intersects(invader) && invader.BlockState != BlockState.Broken)
                    {
                        invaderManager.BlockIsHit(invader);
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
