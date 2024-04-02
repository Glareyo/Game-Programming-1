using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BreakOut
{
    public class DisplayScore : DrawableGameComponent
    {
        string FinalScore {  get; set; }
        SpriteFont Font;
        SpriteBatch sb;
        public Vector2 Location;

        public DisplayScore(Game game, string _FinalScore) : base(game)
        {
            FinalScore = _FinalScore;
            Location = Vector2.Zero;
            sb = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(Font, FinalScore,Location,Microsoft.Xna.Framework.Color.Black);
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
            Font = Game.Content.Load<SpriteFont>("FinalScoreFont");
            base.LoadContent();
        }
    }
}
