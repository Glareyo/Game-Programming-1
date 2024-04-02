using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut
{
    public class BallManager : GameComponent
    {
        public List<Ball> balls;
        
        public BallManager(Game game, Ball startingBall) : base(game)
        {
            balls = new List<Ball>();
            balls.Add(startingBall);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void PowerUpBall(Ball ball,Powerup powerup)
        {
            switch(powerup.Type)
            {
                case PowerUpType.Duplicate:
                    AddBall(ball.Location);
                    break;
            }
        }

        public void AddBall(Vector2 targetLoc)
        {
            Ball b = new Ball(Game);
            b.Location = targetLoc;
            balls.Add(b);
            Game.Components.Add(b);

            b.LaunchBall();
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
