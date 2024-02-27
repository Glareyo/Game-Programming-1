using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame
{
    public class DisplayLight : Sprite
    {
        public DisplayLight(Game game) : base(game)
        {
            TextureName = "light-red";
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
