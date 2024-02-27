using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk3HW_InterestingMovement;

namespace Wk5_OneButtonGame
{
    public class LightLevel : Level
    {
        public enum Difficulty { Easy, Hard };
        Difficulty difficulty;

        public Random rand = new Random();
        //KeyboardHandler keyboard;
        Light light;
        DisplayLight displayLight;
        ScoreBoard scoreBoard;
        Label targetLabel;

        int screenWidth;
        int screenHeight;

        int score;
        int maxRounds;
        int currentRound;

        public LightLevel(Game game,Difficulty _difficulty) : base(game)
        {
            difficulty = _difficulty;

            Enabled = true;
            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;

            score = 0;
            currentRound = 0;
            maxRounds = 5;
        }
        public override void Initialize()
        {
            if (difficulty == Difficulty.Easy)
            {
                light = new Light(Game, rand);
            }
            else
            {
                light = new Light(Game, rand, Light.Difficulty.Hard);
            }
            displayLight = new DisplayLight(Game);

            scoreBoard = new ScoreBoard(Game);
            scoreBoard.Location = new Vector2(1, 1);

            targetLabel = new Label(Game, "Try to match the color\nPress SPACEBAR to Confirm\nTarget Color:");

            LevelComponents.Add(targetLabel);
            LevelComponents.Add(light);
            LevelComponents.Add(displayLight);
            LevelComponents.Add(scoreBoard);

            base.Initialize();
        }

        void CheckForRounds()
        {
            if (currentRound >= maxRounds)
            {
                DisposeLevel();
                Game.Components.Add(new FinalReport(Game, score));
            }
        }
        public override void Update(GameTime gameTime)
        {
            displayLight.Location = new Vector2(screenWidth / 4, screenHeight - displayLight.Texture.Height);
            CheckForRounds();
            SetComponentsLocations();
            //Update keyboard
            KeyboardHandler.Update();
            displayLight.Texture = light.targetTexture;

            //Space pressed
            if (KeyboardHandler.WasKeyPressed(Keys.Space))
            {
                //Check to see if light is either State.On or off
                if (light.IsLightChanging())
                {
                    // Round +1
                    scoreBoard.AddRound();
                    currentRound++;

                    if (light.IsLightCorrect())
                    {
                        score++;
                        scoreBoard.AddPoint();
                    }
                }
            }

            base.Update(gameTime);
        }

        void SetComponentsLocations()
        {
            targetLabel.Location = new Vector2(displayLight.Location.X, displayLight.Location.Y - displayLight.Texture.Height);
        }
    }
}
