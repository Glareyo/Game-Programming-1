using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{

    public enum PowerUpState { Idle, Hit }
    public class Powerup : DrawableSprite
    {
        public PowerUpState State;

        public Powerup(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            State = PowerUpState.Idle;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.SpriteTexture = Game.Content.Load<Texture2D>("powerUps/powerUpBase");
            base.LoadContent();
        }

        public virtual void Hit()
        {
            State = PowerUpState.Hit;
            RemoveSelf();
        }

        public void RemoveSelf()
        {
            Game.Components.Remove(this);
        }
    }
}
