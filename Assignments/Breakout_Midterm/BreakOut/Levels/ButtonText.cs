using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BreakOut.Levels
{
    public class ButtonText : DrawableSprite
    {
        public string Words;
        public GameButtonState State;
        public GameButton Button;

        private Texture2D ButtonSprite;

        public ButtonText(Game game, GameButton _button, string _Words) : base(game)
        {
            Words = _Words;
            Button = _button;

            ButtonSprite = game.Content.Load<Texture2D>("buttons/ButtonIdle");
        }

        public void SetText()
        {
            //Center text
            this.Origin = new Vector2(this.SpriteTexture.Width / 2, this.SpriteTexture.Height / 2);
            //Set Location based on where the button is.
            this.Location = new Vector2(Button.Location.X + ButtonSprite.Width / 2, Button.Location .Y + ButtonSprite.Height / 2);
            //Set the draw order
            this.DrawOrder = 0;
        }

        public override void Initialize()
        {
            State = GameButtonState.Idle;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteTexture = Game.Content.Load<Texture2D>(Words);
            base.LoadContent();
        }

        public void ChangeState(GameButtonState buttonState)
        {
            this.State = buttonState;
        }

        public override void Update(GameTime gameTime)
        {
            switch(State)
            {
                case GameButtonState.Idle:
                    DrawColor = Color.White;
                    break;
                case GameButtonState.Hovering:
                    DrawColor = Color.DarkCyan;
                    break;
                case GameButtonState.Clicked:
                    DrawColor = Color.LightBlue;
                    break;
            }


            //Check to see if the button it depends on is still active
            //If not, remove itself
            if (!Game.Components.Contains(Button)) 
            {
                Game.Components.Remove(this);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
