using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4HW_FPSTesting
{
    public class Sprite : DrawableGameComponent
    {
        public Texture2D Texture;
        public Vector2 Location;
        public Vector2 Direction;
        public float Speed;

        public string TextureName;
        public Vector2 Origin;

        SpriteBatch sb;

        public Sprite(Game game) : base(game)
        {
        }
        public Sprite(Game game,string _textureName) : base(game)
        {
            TextureName = _textureName;
        }

        public override void Initialize()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            Speed = 1;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            Texture = this.Game.Content.Load<Texture2D>(TextureName);
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            Location = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2, this.Game.GraphicsDevice.Viewport.Height / 2);
            Direction = new Vector2(1, 0);
    
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, Texture.Width, Texture.Height), null, Color.White, 0, Origin, SpriteEffects.None, 0);
            sb.End();
            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            this.Location += this.Direction * this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }
    }
}
