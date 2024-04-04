using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class GameOverString : DrawableGameComponent
    {
        SpriteFont font;
        SpriteBatch sb;
        public Vector2 Location;

        public GameOverString(Game game) : base(game)
        {
            Location = Vector2.Zero;
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(font, "Game Over", Location, Microsoft.Xna.Framework.Color.Black);
            sb.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("ScoreBoardFont");
            sb = new SpriteBatch(Game.GraphicsDevice);
            base.LoadContent();
        }
    }
}
