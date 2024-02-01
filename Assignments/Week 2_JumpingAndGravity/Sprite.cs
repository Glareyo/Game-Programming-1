using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Week_2_JumpingAndGravity.Interfaces;

//Credit: Jeff Meyers
// Provided lecture and course materials
// Base Code copied from Jeff Meyer's SimpleMovementJump

namespace Week_2_JumpingAndGravity
{
    public class Sprite //: ISprite
    {
        public Texture2D Texture;// { get; set; }
        public Vector2 Loc;// { get; set; }
        public Vector2 Dir;// { get; set; }
        public float SpeedMax;// { get; set; }
    }
}
