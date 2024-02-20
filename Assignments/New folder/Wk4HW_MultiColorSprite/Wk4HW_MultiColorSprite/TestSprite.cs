using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4HW_MultiColorSprite
{
    public class TestSprite : Sprite
    {
        public TestSprite(Game game) : base(game)
        {
            TextureName = "TestSprite_Multi2";
        }

        public TestSprite(Game game, string _textureName) : base(game, _textureName)
        {

        }
    }
}
