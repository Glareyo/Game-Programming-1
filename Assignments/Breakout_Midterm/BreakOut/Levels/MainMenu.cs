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
        public GameButton TutorialButton;
        public GameButton ExitButton;

        public MainMenu(Game game) : base(game)
        {
            buttonHandler = new ButtonHandler(game);

            StartButton = new GameButton(game,"Start");
            TutorialButton = new GameButton(game,"Tutorial");
            ExitButton = new GameButton(game,"Exit");

            buttonHandler.buttons.Add(StartButton);
            buttonHandler.buttons.Add(TutorialButton);
            buttonHandler.buttons.Add(ExitButton);


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
