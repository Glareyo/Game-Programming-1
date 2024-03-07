using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame
{
    public class Button : Sprite
    {
        public enum State { Idle, Hovering };
        public State state;

        Texture2D HoveringTexture;
        Texture2D IdleTexture;

        public TextBox buttonText;
        string text;

        public Button(Game game, string _text) : base(game)
        {
            TextureName = "button-idle";
            text = _text;   
            state = State.Idle;
        }

        protected override void LoadContent()
        {
            HoveringTexture = Game.Content.Load<Texture2D>("button-hover");
            IdleTexture = Game.Content.Load<Texture2D>("button-idle");

            buttonText = new TextBox(Game);

            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            if (state == State.Idle)
            {
                Texture = IdleTexture;
            }
            else
            {
                Texture = HoveringTexture;
            }

            buttonText.Location = new Vector2(this.Location.X, this.Location.Y);
            buttonText.text = text;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            buttonText.Draw(gameTime);
        }

        public bool IsClicked()
        {
            if (state == State.Hovering)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeState()
        {
            if (state == State.Idle)
            {
                state = State.Hovering;
                Texture = HoveringTexture;
            }
            else
            {
                state = State.Idle;
                Texture = IdleTexture;
            }
        }
    }
}
