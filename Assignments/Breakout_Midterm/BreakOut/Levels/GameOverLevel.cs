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
    public class GameOverLevel : Level
    {
        public GameButton RestartLevelButton;
        public GameButton MainMenuButton;
        public GameButton ExitButton;

        ButtonHandler bh;
        GameOverString gameOverString;

        public GameOverLevel(Game game, string _name) : base(game, _name)
        {
            bh = new ButtonHandler(Game);

            bh.buttons.Add(RestartLevelButton = new GameButton(game,"Restart Level"));
            bh.buttons.Add(MainMenuButton = new GameButton(game, "Main Menu"));
            bh.buttons.Add(ExitButton = new GameButton(game, "Exit"));
            gameOverString = new GameOverString(Game);

            LevelComponents.Add(bh);
            LevelComponents.Add(gameOverString);
        }

        public override void DisposeLevel()
        {
            bh.DisposeButtons();
            base.DisposeLevel();
        }

        public override void Initialize()
        {
            Viewport vp = Game.GraphicsDevice.Viewport;
            bh.ButtonLocation = new Vector2(vp.Width / 2, vp.Height / 4);
            gameOverString.Location.X = bh.ButtonLocation.X;
            gameOverString.Location.Y = bh.ButtonLocation.Y - 15;

            base.Initialize();
        }

        public override void StartLevel()
        {
            bh.AddButtonsToGame();
            base.StartLevel();
        }

        public override void Update(GameTime gameTime)
        {
            if (RestartLevelButton.IsClicked() || MainMenuButton.IsClicked() || ExitButton.IsClicked()) 
            {
                this.State = LevelState.Disabled;
            }


            base.Update(gameTime);
        }
    }
}
