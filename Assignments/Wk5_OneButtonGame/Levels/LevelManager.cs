using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Wk5_OneButtonGame.Levels
{
    public class LevelManager : GameComponent
    {
        List<Level> levels;

        Menu menu;
        LightLevel lightLevel;
        FinalReport finalReport;

        public LevelManager(Game game) : base(game)
        {
            levels = new List<Level>();

            levels.Add(menu = new Menu(Game));
            levels.Add(lightLevel = new LightLevel(Game,LightLevel.Difficulty.Easy));
            levels.Add(finalReport = new FinalReport(Game,0));


            menu.StartLevel();
            AddLevels();
        }

        void AddLevels()
        {
            foreach(Level level in levels)
            {
                Game.Components.Add(level);
            }
        }
        public void CheckLevelStatus()
        {
            if (menu.LevelState == Level.State.Disabled)
            {
                if (menu.selectedOption == 1)
                {
                    lightLevel = new LightLevel(Game, LightLevel.Difficulty.Easy);
                }
                else
                {
                    lightLevel = new LightLevel(Game, LightLevel.Difficulty.Easy);
                }
                menu.Dispose();
            }

        }
    }
}
