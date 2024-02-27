using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk3HW_InterestingMovement;

namespace Wk5_OneButtonGame
{
    public class FinalReport : GameComponent
    {
        int finalScore;
        Button box;

        public FinalReport(Game game,int _finalScore) : base(game)
        {
            this.finalScore = _finalScore;
        }
        public override void Initialize()
        {
            box = new Button(Game, $"Game Over\nScore: {finalScore}\nPress SPACE to Continue");
            Game.Components.Add(box);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            box.Location = new Vector2(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);
            box.buttonText.SetLocationInSprite(box);

            KeyboardHandler.Update();
            if (KeyboardHandler.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                Game.Components.Add(new Menu(Game));
                RemoveSelf();
            }
        }

        void RemoveSelf()
        {
            Game.Components.Remove(box);
            Game.Components.Remove(this);
        }
    }
}
