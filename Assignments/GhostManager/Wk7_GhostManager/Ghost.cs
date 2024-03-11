using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk7_GhostManager
{
    public class Ghost : DrawableSprite
    {
        string textureName;

        public Ghost(Game game) : base(game)
        {
            
        }
        public Ghost(Game game, string TextureName) : base(game)
        {
            textureName = TextureName;
            Speed = 0.5f;
            //Direction = new Vector2(1, 0);
        }

        protected override void LoadContent()
        {
            spriteTexture = Game.Content.Load<Texture2D>(textureName);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.Location += this.Direction * this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(IsOffScreen())
            {
                WrapAroundScreen();
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
