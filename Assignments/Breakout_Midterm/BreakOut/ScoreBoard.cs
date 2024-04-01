using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class ScoreBoard : DrawableGameComponent
    {
        SpriteFont scoreBoardFont;
        SpriteBatch sb;

        int numOfLives;

        int currentScore;
        double currentTime;
        int currentInvadersDestroyed;
        int currentPowerupsCollected;

        string scoreString;
        string timeString;
        string invadersDestroyedString;
        string powerupsCollectedString;

        int fontMargin = 15;

        public ScoreBoard(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            currentScore = 0;
            currentTime = 0;
            currentInvadersDestroyed = 0;
            currentPowerupsCollected = 0;
            numOfLives = 3;

            UpdateStrings();

            sb = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            scoreBoardFont = Game.Content.Load<SpriteFont>("ScoreBoardFont");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateCurrentTime(gameTime);
            UpdateStrings();
            base.Update(gameTime);
        }

        void UpdateStrings()
        {
            scoreString = $"Score: {currentScore}";
            timeString = $"Time: {currentTime}";
            invadersDestroyedString = $"Invaders Destroyed: {currentInvadersDestroyed}";
            powerupsCollectedString = $"Powerups Collected: {currentPowerupsCollected}";
        }

        public void InvaderDestroyed()
        {
            currentInvadersDestroyed++;
            currentScore += 10;
        }
        public void PowerupCollected()
        {
            currentPowerupsCollected++;
            currentScore += 5;
        }
        public void UpdateCurrentTime(GameTime gameTime)
        {
            currentTime = gameTime.TotalGameTime.TotalSeconds;
        }
        public void LoseALife()
        {
            numOfLives--;
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(scoreBoardFont,scoreString, new Vector2(10,fontMargin),Microsoft.Xna.Framework.Color.Black);
            sb.DrawString(scoreBoardFont,timeString, new Vector2(10,fontMargin*2),Microsoft.Xna.Framework.Color.Black);
            sb.DrawString(scoreBoardFont,invadersDestroyedString, new Vector2(10,fontMargin*3),Microsoft.Xna.Framework.Color.Black);
            sb.DrawString(scoreBoardFont, powerupsCollectedString, new Vector2(10,fontMargin*4),Microsoft.Xna.Framework.Color.Black);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
