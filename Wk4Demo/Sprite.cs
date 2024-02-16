using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4Demo
{
    public class Sprite : DrawableGameComponent //Becomes a child of a drawable game component
    {
        Texture2D Texture { get; set; }
        Vector2 Location, Direction, Origin;
        public float Speed;

        SpriteBatch sb;

        public Sprite(Game game) : base(game)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Speed = 100;
            Location = new Vector2(50, 50);
            Direction = new Vector2(1, 0);
            Texture = this.Game.Content.Load<Texture2D>("pacManSingle");

            sb = new SpriteBatch(this.Game.GraphicsDevice);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            this.Location += this.Direction * this.Speed * (float)(gameTime.ElapsedGameTime.TotalMilliseconds);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime) 
        {
            sb.Begin();
            
            sb.Draw(Texture, Location, Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
