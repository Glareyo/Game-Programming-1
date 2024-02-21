using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Wk4HW_LargeMultiColorSprite
{
    public class TestSpriteRepo
    {
        List<TestSprite> spritesList;
        public List<TestSprite> List { get { return spritesList; } }

        public void AddTestSprite(TestSprite sprite)
        {
            spritesList.Add(sprite);
        }
        public void RemoveTestSprite(TestSprite sprite)
        {
            spritesList.Remove(sprite);
        }
        public void SetLocation(TestSprite sprite, Vector2 newLoc)
        {
            sprite.Location = newLoc;
        }
    }
}
