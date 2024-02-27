using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Wk3HW_InterestingMovement;

namespace Wk5_OneButtonGame
{
    public class Menu : Level
    {
        Button easyButton;
        Button hardButton;
        Button exitButton;
        List<Button> buttons;
        int selectedButton;

        public Menu(Game game) : base(game)
        {
            
        }
        public override void Initialize()
        {
            buttons = new List<Button>();

            easyButton = new Button(Game,"EASY");
            hardButton = new Button(Game,"Hard");
            exitButton = new Button(Game,"Exit");

            selectedButton = 0;
            buttons.Add(easyButton);
            buttons.Add(hardButton);
            buttons.Add(exitButton);


            LevelComponents.Add(easyButton);
            LevelComponents.Add(hardButton);
            LevelComponents.Add(exitButton);

            easyButton.ChangeState();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            SetLocations();

            KeyboardHandler.Update();
            //Check to see if Up or Down or Space key is pressed
            if (KeyboardHandler.WasKeyPressed(Keys.Up))
            {
                buttons[selectedButton].ChangeState();
                if (selectedButton == 0)
                {
                    selectedButton = buttons.Count - 1;
                }
                else
                {
                    selectedButton--;
                }
                buttons[selectedButton].ChangeState();
            }
            else if (KeyboardHandler.WasKeyPressed(Keys.Down))
            {
                buttons[selectedButton].ChangeState();
                if (selectedButton == buttons.Count - 1)
                {
                    selectedButton = 0;
                }
                else
                {
                    selectedButton++;
                }
                buttons[selectedButton].ChangeState();
            }
            //Button selected
            else if (KeyboardHandler.WasKeyPressed(Keys.Space))
            {
                if (easyButton.IsClicked())
                {
                    DisposeLevel();
                    Game.Components.Add(new LightLevel(Game, LightLevel.Difficulty.Easy));
                }
                else if (hardButton.IsClicked())
                {
                    DisposeLevel();
                    Game.Components.Add(new LightLevel(Game, LightLevel.Difficulty.Hard));
                }
                else if (exitButton.IsClicked())
                {
                    Game.Exit();
                }
            }
        }

        public void SetLocations()
        {
            float textureHeight = easyButton.Texture.Height;
            float x = 0 + easyButton.Texture.Width;

            easyButton.Location = new Vector2(x, 0+textureHeight);
            hardButton.Location = new Vector2(x, easyButton.Location.Y+textureHeight+10);
            exitButton.Location = new Vector2(x, hardButton.Location.Y+textureHeight+10);
        }
    }
}
