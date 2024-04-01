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
        GameHandler gameHandler;

        public InvaderLevel(Game game, int _numSmallUFOs, int _numLargeUFOS) : base(game)
        {
            numSmallUFOs = _numSmallUFOs;
            numLargeUFOs = _numLargeUFOS;

            gameHandler = new GameHandler(Game);
            LevelComponents.Add(gameHandler);
        }

        public override void Initialize()
        {
            StartLevel();
            base.Initialize();
        }
    }
}
