using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public class InvaderLevel : Level
    {
        int numSmallUFOs;
        int numLargeUFOs;
        GamePlayHandler gamePlayHandler;

        public ScoreBoard Scoreboard { get; private set; }

        public InvaderLevel(Game game, string _name, int _numSmallUFOs, int _numLargeUFOS) : base(game,_name)
        {
            levelName = _name;
            numSmallUFOs = _numSmallUFOs;
            numLargeUFOs = _numLargeUFOS;

            gamePlayHandler = new GamePlayHandler(Game, numSmallUFOs, numLargeUFOs);
            LevelComponents.Add(gamePlayHandler);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            //All Invaders destroyed and no more spawning
            if (gamePlayHandler.State == GamePlayState.Disabled)
            {
                Scoreboard = gamePlayHandler.GetScoreBoard;
                DisableLevel();
                gamePlayHandler.ClearComponents(); 
            }
            base.Update(gameTime);
        }
    }
}
