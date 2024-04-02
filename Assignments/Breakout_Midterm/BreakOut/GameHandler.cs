﻿using BreakOut.Levels;
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

        List<Level> allLevels;

        int levelIndex;

        public GameHandler(Game game) : base(game)
        {
            levelIndex = 0;

            ResetLevels();

            levelHandler = new LevelHandler(game, allLevels[0]);

            Game.Components.Add(levelHandler);
        }

        public void ResetLevels()
        {
            allLevels = new List<Level>();

            allLevels.Add(new MainMenu(Game, "mainMenu"));
            allLevels.Add(new InvaderLevel(Game, "level1", 1, 0));
            allLevels.Add(new InvaderLevel(Game, "level2", 2, 0));
            allLevels.Add(new InvaderLevel(Game, "level3", 30, 0));
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

        Level GetNextLevel()
        {
            levelIndex++;
            if (levelIndex >= allLevels.Count)
            {
                levelIndex = 0;
                ResetLevels();
            }

            return allLevels[levelIndex];
        }

        CompletedLevel ShowCompletedLevel(InvaderLevel level)
        {
            return new CompletedLevel(Game, "completedLevel", level.Scoreboard);
        }

        void ChangeLevel(Level currentLevel)
        {
            if (currentLevel.Name == "mainMenu")
            {
                if ((currentLevel as MainMenu).StartButton.IsClicked())
                {
                    levelHandler.NextLevel(GetNextLevel());
                }
                else if ((currentLevel as MainMenu).TutorialButton.IsClicked())
                {
                    Game.Exit();
                }
                else if ((currentLevel as MainMenu).ExitButton.IsClicked())
                {
                    Game.Exit();
                }
            }
            else if (currentLevel is InvaderLevel) //Credit: Jeff Meyers. Showed how to check the Instance type of an instance.
            {
                levelHandler.NextLevel(ShowCompletedLevel(currentLevel as InvaderLevel));
            }
            else 
            {
                levelHandler.NextLevel(GetNextLevel()); 
            }
        }
    }
}
