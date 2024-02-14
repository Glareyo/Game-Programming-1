using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4Demo
{
    public class PacMan : Sprite
    {
        public PacMan(Game game) : base(game)
        {
            Speed = 200f;
        }
    }
}
