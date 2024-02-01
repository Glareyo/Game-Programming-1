using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Credit: Jeff Meyers
// Provided lecture and course materials
// Base Code copied from Jeff Meyer's SimpleMovementJump

namespace Week_2_JumpingAndGravity
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Loc, Dir;
        public float SpeedMax;
    }
}
