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

        GameButton StartButton;
        GameButton TutorialButton;
        GameButton ExitButton;
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
            buttonHandler.AddButtonsToGame();
            StartLevel();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (buttonHandler.ButtonSelected == ExitButton) 
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
