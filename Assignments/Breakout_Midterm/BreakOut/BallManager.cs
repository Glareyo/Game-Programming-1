using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut
{
    public enum BallManagerState { Running, Stopped}

    public class BallManager : GameComponent
    {
        public List<Ball> balls;
        GameTime currentGameTime;

        BallManagerState ballManagerState;
        public BallManagerState State {  get { return ballManagerState; } }
        
        public BallManager(Game game, Ball startingBall) : base(game)
        {
            balls = new List<Ball>();
            ballManagerState = BallManagerState.Running;
            balls.Add(startingBall);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            currentGameTime = gameTime;
            RemoveMissingBalls();
            base.Update(gameTime);
        }

        void RemoveMissingBalls()
        {
            for(int i = 0; i < balls.Count; i++)
            {
                Ball ball = balls[i];
                if (ball.State == Ball.BallState.Destroyed)
                {
                    i--;
                    balls.Remove(ball);
                    Game.Components.Remove(ball);

                    
                }
            }
            //Check to see if there are any balls left
            if (balls.Count <= 0)
            {
                ballManagerState = BallManagerState.Stopped;
            }
        }

        public void PowerUpBall(Ball ball,Powerup powerup)
        {
            switch(powerup.Type)
            {
                case PowerUpType.Duplicate:
                    //AddBall(ball.Location, ball.SpriteTexture);
                    AddBall(ball, ball.SpriteTexture);
                    break;
            }
        }

        public void AddBall(Ball ball, Texture2D ballText)
        {
            Ball b = new Ball(Game);
            //b.Origin = new Vector2(ballText.Width / 2, ballText.Height / 2);
            //b.Location = targetLoc;

            balls.Add(b);
            Game.Components.Add(b);

            b.Location = ball.Location;
            b.LaunchBall(new Vector2(ball.Direction.X *-1, ball.Direction.Y));
        }

        public void AddBall(Vector2 targetLoc, Texture2D ballText)
        {
            Ball b = new Ball(Game);
            b.Origin = new Vector2(ballText.Width / 2, ballText.Height / 2);
            b.Location = targetLoc;
            
            balls.Add(b);
            Game.Components.Add(b);

            //b.LaunchBall();
        }

        public void ClearComponents()
        {
            foreach(Ball b in balls) 
            {
                Game.Components.Remove(b);
            }
        }
    }
}
