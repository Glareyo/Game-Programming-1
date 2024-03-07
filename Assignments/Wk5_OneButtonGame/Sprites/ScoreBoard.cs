using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame
{
    public class ScoreBoard : Sprite
    {
        int round;
        int score;
        TextBox textBox;

        public ScoreBoard(Game game) : base(game)
        {
            TextureName = "score-board";
            round = 0;
            score = 0;
        }
        public void AddRound()
        {
            round++;
        }
        public void AddPoint() 
        { 
            score++; 
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            Origin = new Vector2(0, 0);
            textBox = new TextBox(Game);

        }

        public override void Update(GameTime gameTime)
        {
            textBox.Location = new Vector2(Location.X + 10, Location.Y + 10);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            textBox.text = $"Round: {round}\nScore: {score}";
            textBox.Draw(gameTime);
        }
    }
}
