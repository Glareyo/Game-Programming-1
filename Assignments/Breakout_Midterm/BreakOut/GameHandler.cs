using BreakOut.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class GameHandler : GameComponent
    {
        LevelHandler levelHandler;

        MainMenu mainMenu;
        InvaderLevel level1;

        CompletedLevel levelComplete;

        public GameHandler(Game game) : base(game)
        {
            mainMenu = new MainMenu(game);

            levelHandler = new LevelHandler(game, mainMenu);

            Game.Components.Add(levelHandler);
        }

        public void StartGame()
        {
            levelHandler.BeginCurrentLevel();
        }

        public override void Initialize()
        {
            base.Initialize();
            StartGame();
        }

        public override void Update(GameTime gameTime)
        {
            CheckLevelStatus();
            base.Update(gameTime);
        }

        void CheckLevelStatus()
        {
            if (levelHandler.GetCurrentLevel.State == LevelState.Disabled) 
            {
                ChangeLevel(levelHandler.GetCurrentLevel);
            }
        }

        void ChangeLevel(Level currentLevel)
        {
            if (currentLevel == mainMenu)
            {
                if (mainMenu.StartButton.IsClicked())
                {
                    level1 = new InvaderLevel(Game, 1, 0);
                    levelHandler.NextLevel(level1);
                }
                else if (mainMenu.TutorialButton.IsClicked())
                {
                    Game.Exit();
                }
                else if (mainMenu.ExitButton.IsClicked())
                {
                    Game.Exit();
                }
            }
            else if (currentLevel == level1)
            {
                levelComplete = new CompletedLevel(Game, level1.Scoreboard);
                levelHandler.NextLevel(levelComplete);
            }
            else if (currentLevel == levelComplete)
            {
                mainMenu = new MainMenu(Game);
                levelHandler.NextLevel(mainMenu);
            }

        }
    }
}
