using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4HW_FPSTesting
{
    public class PacMan : Sprite
    {
        public PacMan(Game game) : base(game)
        {
            TextureName = "pacManSingle";
        }

        public PacMan(Game game, string _textureName) : base(game, _textureName)
        {
           
        }
    }
}
