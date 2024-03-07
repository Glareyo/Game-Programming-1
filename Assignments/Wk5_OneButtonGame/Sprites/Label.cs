using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame.Sprites
{
    public class Label : Sprite
    {
        public TextBox textBox;
        string text;

        public Label(Game game, string _text) : base(game)
        {
            TextureName = "button-idle";
            text = _text;
        }

        protected override void LoadContent()
        {
            textBox = new TextBox(Game);
            Game.Components.Add(textBox);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            textBox.Location = new Vector2(Location.X - Texture.Width / 2 + 5, Location.Y - Texture.Height / 2);
            textBox.text = text;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            textBox.Draw(gameTime);
        }
    }
}
