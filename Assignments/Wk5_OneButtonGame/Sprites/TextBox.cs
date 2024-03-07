using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame
{
    public class TextBox : DrawableGameComponent
    {
        public string text = "";
        public Vector2 Location;
        SpriteFont font;
        SpriteBatch sb;

        public TextBox(Game game) : base(game)
        {
            sb = new SpriteBatch(game.GraphicsDevice);
            Location = new Vector2(0,0);
            LoadContent();
        }

        public TextBox(Game game,string _text) : base(game)
        {
            sb = new SpriteBatch(game.GraphicsDevice);
            Location = new Vector2(0, 0);
            text = _text;
            LoadContent();
        }

        public void SetLocationInSprite(Sprite sprite)
        {
            float right = sprite.Location.X + sprite.Texture.Width;
            float bottom = sprite.Location.Y + sprite.Texture.Height;

            Location = new Vector2(right/2, sprite.Location.Y-3);
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("TextFont");
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(font, text, Location, Color.Black);
            sb.End();
        }
    }
}
