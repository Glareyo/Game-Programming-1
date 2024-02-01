using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Week_2_JumpingAndGravity.Interfaces
{
    public interface ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; } 
        public Vector2 Direction { get; set; }
        public float SpeedMax { get; set; }
    }
}
