using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public class LevelHandler : GameComponent
    {
        public List<Level> levels;

        Level CurrentLevel;
        //int CurrentLevel;

        public LevelHandler(Game game, Level StartingLevel) : base(game)
        {
            levels = new List<Level>();
            CurrentLevel = StartingLevel;
        }

        //public Level GetCurrentLevel { get { return levels[CurrentLevel]; } }
        public Level GetCurrentLevel { get { return CurrentLevel; } }

        public override void Initialize()
        {
            //CurrentLevel = 0;
            base.Initialize();
        }

        public void BeginCurrentLevel()
        {
            Game.Components.Add(CurrentLevel);
            CurrentLevel.StartLevel();
        }

        public void NextLevel(Level level)
        {
            CurrentLevel.DisposeLevel();
            Game.Components.Remove(CurrentLevel);

            CurrentLevel = level;
            BeginCurrentLevel();
        }

        public void AddLevel(Level level)
        {
            //levels.Add(level);
        }

        public void AddLevelsToGame()
        {
            /*foreach(Level level in levels)
            {
                Game.Components.Add(level);
            }*/
        }

        public void GoToNextLevel()
        {
            /*levels[CurrentLevel].DisposeLevel();

            CurrentLevel++;
            if (CurrentLevel >= levels.Count) 
            {
                CurrentLevel = 0;
            }

            levels[CurrentLevel].StartLevel();*/
        }

        public void JumpToLevel(Level level)
        {
            /*levels[CurrentLevel].DisposeLevel();

            for(int i = 0; i < levels.Count; i++) 
            {
                if (levels[i] == level) 
                {
                    CurrentLevel = i;
                }
            }
         
            levels[CurrentLevel].StartLevel();*/
        }
    }
}
