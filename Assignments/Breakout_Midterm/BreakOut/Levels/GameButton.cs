using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public enum GameButtonState { Idle, Hovering, Clicked }

    public class GameButton : DrawableSprite
    {
        ButtonText text;
        GameButtonState State;

        public GameButton(Game game, string buttonText) : base(game)
        {
            text = new ButtonText(game, this, $"buttons/ButtonText/" + buttonText);
            Game.Components.Add(text);
        }

        public override void Initialize()
        {
            State = GameButtonState.Idle;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteTexture = Game.Content.Load<Texture2D>("buttons/ButtonIdle");
            base.LoadContent();
        }

        public void SetLocation(Vector2 Loc)
        {
            this.Location = Loc;
            text.SetText();
            this.DrawOrder = -1;
        }

        public void Idle()
        {
            State = GameButtonState.Idle;
        }
        public void Hover()
        {
            State = GameButtonState.Hovering;
        }
        public void Clicked()
        {
            State = GameButtonState.Clicked;
        }

        public override void Update(GameTime gameTime)
        {
            switch (State)
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
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
