using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public class ButtonHandler : DrawableGameComponent
    {
        public List<GameButton> buttons;
        int currentSelect;
        public GameButton ButtonSelected;

        /// <summary>
        /// Margin Between Buttons
        /// </summary>
        public int margin;

        /// <summary>
        /// Where to general buttons will be.
        /// </summary>
        public Vector2 ButtonLocation;

        private Texture2D ButtonSprite;

        public ButtonHandler(Game game) : base(game)
        {
            buttons = new List<GameButton>();
            ButtonSelected = null;
            margin = 0;
            ButtonLocation = Vector2.Zero;
            currentSelect = 0;

            ButtonSprite = game.Content.Load<Texture2D>("buttons/ButtonIdle");
        }

        public override void Initialize()
        {
            SetButtonLocations();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            base.Update(gameTime);
        }

        /// <summary>
        /// Go up to next button
        /// </summary>
        public void UpdateSelectionUp()
        {
            currentSelect--;
            if (currentSelect < 0) 
            {
                currentSelect = buttons.Count - 1;
            }
        }

        /// <summary>
        /// Go Down to Next Button
        /// </summary>
        public void UpdateSelectionDown()
        {
            currentSelect++;
            if (currentSelect >= buttons.Count)
            {
                currentSelect = 0;
            }
        }

        public void UpdateState()
        {
            foreach (GameButton button in buttons) 
            {
                button.Idle();
            }
            
            buttons[currentSelect].Hover();

        }

        public void HandleInput()
        {
            if (KeyboardHandler.WasKeyPressed(Keys.Down))
            {
                UpdateSelectionDown();
                UpdateState();
            }
            else if (KeyboardHandler.WasKeyPressed(Keys.Up))
            {
                UpdateSelectionUp();
                UpdateState();
            }
            else if (KeyboardHandler.WasKeyPressed(Keys.Enter))
            {
                buttons[currentSelect].Clicked();
            }
        }

        public void SetButtonLocations()
        {
            //Set the margin
            if (margin == 0)
            {
                margin = 5;
            }

            int locationWithMargin = 0;

            //Set the button Locations
            foreach (GameButton button in buttons)
            {
                button.SetLocation(new Vector2(ButtonLocation.X, ButtonLocation.Y + locationWithMargin));

                locationWithMargin += ButtonSprite.Height + margin;
            }
        }

        public void AddButtonsToGame()
        {
            foreach(GameButton button in buttons)
            {
                Game.Components.Add(button);
            }
        }

        public void DisposeButtons()
        {
            foreach(GameButton button in buttons)
            {
                Game.Components.Remove(button);
            }
        }
    }
}
