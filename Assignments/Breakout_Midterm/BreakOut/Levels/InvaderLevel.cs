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
        GamePlayHandler gameHandler;

        public ScoreBoard Scoreboard { get; private set; }

        public InvaderLevel(Game game, int _numSmallUFOs, int _numLargeUFOS) : base(game)
        {
            numSmallUFOs = _numSmallUFOs;
            numLargeUFOs = _numLargeUFOS;

            gameHandler = new GamePlayHandler(Game, numSmallUFOs, numLargeUFOs);
            LevelComponents.Add(gameHandler);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            //All Invaders destroyed and no more spawning
            if (gameHandler.State == GamePlayState.Disabled)
            {
                Scoreboard = gameHandler.GetScoreBoard;
                DisableLevel();
                gameHandler.ClearComponents(); 
            }
            base.Update(gameTime);
        }
    }
}
