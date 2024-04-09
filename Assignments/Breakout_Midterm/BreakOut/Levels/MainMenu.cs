using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public class MainMenu : Level
    {
        ButtonHandler buttonHandler;

        public GameButton StartButton;
        public GameButton ExitButton;
        TutorialBox tb;

        public MainMenu(Game game, string _name) : base(game, _name)
        {
            buttonHandler = new ButtonHandler(game);

            StartButton = new GameButton(game,"Start");
            ExitButton = new GameButton(game,"Exit");

            tb = new TutorialBox(game);
            tb.Location = new Vector2(Game.GraphicsDevice.Viewport.Width / 3, Game.GraphicsDevice.Viewport.Height / 4);


            buttonHandler.buttons.Add(StartButton);
            buttonHandler.buttons.Add(ExitButton);

            LevelComponents.Add(tb);
            LevelComponents.Add(buttonHandler);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void StartLevel()
        {
            buttonHandler.AddButtonsToGame();

            base.StartLevel();
        }

        public override void Update(GameTime gameTime)
        {
            if (StartButton.IsClicked())
            {
                this.DisableLevel();
            }
            else if (ExitButton.IsClicked()) 
            {
                Game.Exit();
            }
            base.Update(gameTime);
        }

        public override void DisposeLevel()
        {
            buttonHandler.DisposeButtons();
            base.DisposeLevel();
        }
    }
}
