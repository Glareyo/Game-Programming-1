using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Wk5_OneButtonGame
{
    public class Light : Sprite
    {
        public enum Difficulty { Easy, Hard };
        enum State { OFF, ON,INCORRECT,CORRECT };
        
        Texture2D offTexture;
        Texture2D correctTexture;
        Texture2D incorrectTexture;
        Texture2D[] colorTextures = new Texture2D[4];

        public Texture2D targetTexture;

        State state;

        int maxTime = 120;
        int minTime = 30;
        int currentTime = 5;

        Random rand;

        public Light(Game game) : base(game)
        {
        }
        public Light(Game game, Random _rand) : base(game)
        {
            rand = _rand;
        }
        public Light(Game game, Random _rand,Difficulty difficulty) : base(game)
        {
            rand = _rand;
            if (difficulty == Difficulty.Hard)
            {
                minTime /= 2;
                maxTime /= 4;
            }
        }

        protected override void LoadContent()
        {
            TextureName = "light-off";

            offTexture = this.Game.Content.Load<Texture2D>("light-off");
            correctTexture = this.Game.Content.Load<Texture2D>("light-correct");
            incorrectTexture = this.Game.Content.Load<Texture2D>("light-incorrect");
            colorTextures[0] = this.Game.Content.Load<Texture2D>("light-blue");
            colorTextures[1] = this.Game.Content.Load<Texture2D>("light-green");
            colorTextures[2] = this.Game.Content.Load<Texture2D>("light-yellow");
            colorTextures[3] = this.Game.Content.Load<Texture2D>("light-red");

            targetTexture = colorTextures[0];

            state = State.OFF;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.Seconds / 1000;


            if (state == State.CORRECT)
            {
                Texture = correctTexture;
            }
            else if (state == State.INCORRECT)
            {
                Texture = incorrectTexture;
            }
            //Check current time
            currentTime--;
            if (currentTime <= 0)
            {
                ChangeState();
                currentTime = rand.Next(minTime, maxTime);
            }
            base.Update(gameTime);
        }
        void ChangeState()
        {
            switch (state)
            {
                case State.OFF:
                    //Randomly select a color to display
                    //Change state to on
                    Texture = SelectNewColor();
                    state = State.ON;
                    break;
                case State.ON:
                    //Currently on, change to off
                    Texture = offTexture;
                    state = State.OFF;
                    break;
                case State.INCORRECT:
                case State.CORRECT:
                    //Change to off to start over
                    Texture = offTexture;
                    targetTexture = SelectNewColor();
                    state = State.OFF;
                    break;
            }
        }
        
        Texture2D SelectNewColor()
        {
            return colorTextures[rand.Next(colorTextures.Length)];
        }

        public bool IsLightChanging()
        {
            //Check to see if light is currently changing colors
            if (state == State.ON || state == State.OFF)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsLightCorrect()
        {
            currentTime = maxTime / 2;

            if (state == State.OFF)
            {//Error => Player loses point
                state = State.INCORRECT;
                return false;
            }
            else
            {
                //Check to see if texture is target texture
                if (Texture == targetTexture)
                {// Textures are the same
                    state = State.CORRECT;
                    return true;
                }
                else
                {//Textures are incorrect
                    state = State.INCORRECT;
                    return false;
                }
            }
        }
    }
}
