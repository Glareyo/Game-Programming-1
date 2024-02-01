using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_JumpingAndGravity.Interfaces;

namespace Week_2_JumpingAndGravity
{
    public class SpriteRepo
    {
        List<Sprite> spritesList;

        public SpriteRepo()
        {
            spritesList = new List<Sprite>();
        }


        public string AddSprite(Sprite sprite)
        {
            if (spritesList.Contains(sprite))
            {
                return "Sprite already in list";
            }
            else
            {
                spritesList.Add(sprite);
                return "Sprite added to list";
            }
        }
        public string Remove(Sprite sprite)
        {
            if (spritesList.Contains(sprite))
            {
                spritesList.Remove(sprite);
                return "Sprite removed from list";
            }
            else
            {
                return "Sprite not in list";
            }
        }
    }
}
