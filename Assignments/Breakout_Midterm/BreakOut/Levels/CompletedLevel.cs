using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut.Levels
{
    public class CompletedLevel : Level
    {
        DisplayScore score;
        GameButton NextButton;
        ButtonHandler bh;

        public CompletedLevel(Game game,string _name) : base(game, _name)
        {
        }
        public CompletedLevel(Game game, string _name, ScoreBoard _scoreBoard) : base(game, _name)
        {
            score = new DisplayScore(game, GetScoreString(_scoreBoard));
            NextButton = new GameButton(game, "Next Level");
            bh = new ButtonHandler(game);

            bh.buttons.Add(NextButton);

            LevelComponents.Add(NextButton);
            LevelComponents.Add(bh);
            LevelComponents.Add(score);
        }

        public string GetScoreString(ScoreBoard scoreboard)
        {
            return $"Score: {scoreboard.GetScore}" +
                $"Time: {scoreboard.GetTime}s" +
                $"\nNumber Of Invaders Destroy: {scoreboard.GetInvadersDestroyed}" +
                $"\nNumber of Powerups Collected: {scoreboard.GetPowerupsCollected}";

        }

        public override void DisposeLevel()
        {
            bh.DisposeButtons();
            base.DisposeLevel();
        }

        public override void Initialize()
        {
            Viewport vp = Game.GraphicsDevice.Viewport;

            score.Location = new Vector2(vp.Width / 2, vp.Height / 4);
            bh.ButtonLocation = new Vector2(vp.Width / 2, vp.Height / 2);
            base.Initialize();
        }

        public override void StartLevel()
        {
            base.StartLevel();
        }

        public override void Update(GameTime gameTime)
        {
            if (NextButton.IsClicked())
            {
                this.DisableLevel();
            }
            base.Update(gameTime);
        }
    }
}
