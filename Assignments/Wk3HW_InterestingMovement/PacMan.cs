using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Credit: Jeff Meyers
// Provided lecture and course materials
// Base Code copied from Jeff Meyer's SimpleMovementJump

namespace Wk3HW_InterestingMovement
{
    public class PacMan : Sprite
    {
        enum PacManState { Regular,Running,Spinning }
        PacManState CurrentState;

        KeyboardHandler inputKeyboard;  //Instance of class that handles keyboard input

        public Keys UpKey;
        public Keys DownKey;
        public Keys LeftKey;
        public Keys RightKey;

        public Color textureColor;

        float StateRotation;
        float BaseRotation;

        public PacMan(Game _game) : base(_game)
        {
            inputKeyboard = new KeyboardHandler();

            UpKey = Keys.Up;
            DownKey = Keys.Down;
            LeftKey = Keys.Left;
            RightKey = Keys.Right;

            SpeedMax = 200;
            
            TextureName = "pacManSingle";
            textureColor = Color.Green;

            StateRotation = Rotation;
            CurrentState = PacManState.Regular;
        }
        public PacMan(Game _game, Keys _UpKey, Keys _DownKey, Keys _LeftKey, Keys _RightKey, Color _textureColor) : base(_game)
        {
            inputKeyboard = new KeyboardHandler();

            UpKey = _UpKey;
            DownKey = _DownKey;
            LeftKey = _LeftKey;
            RightKey = _RightKey;

            textureColor = _textureColor;
        }

        public void UpdatePacManMove(float time)
        {
            float tempSpeed = SpeedMax;
            if (CurrentState == PacManState.Running)
            {// Pacman is running
                tempSpeed *= 3;
                if (Rotation == BaseRotation + 15)
                {
                    Rotation = BaseRotation - 15;
                }
                else
                {
                    Rotation = BaseRotation + 15;
                }
            }
            if (CurrentState == PacManState.Spinning)
            {// Pacman is rolling
                if (Dir.X == -1) //Going back
                {
                    Rotation -= 10;
                }
                else
                {
                    Rotation += 10;
                }

                if (Rotation >= 360)
                {
                    Rotation = 0;
                }
                else if(Rotation <= 0)
                {
                    Rotation = 360;
                }
                tempSpeed *= 0.5f;
                switch(Rotation)
                {
                    case 0: 
                        Loc.Y -= 5;
                        break;
                    case 90:
                        Loc.Y += 5;
                        break;
                    case 180: 
                        Loc.Y += 5;
                        break;
                    case 270: 
                        Loc.Y -= 5;
                        break;
                }

            }
            if (CurrentState == PacManState.Regular)
            {// Pacman is staying regular
                Rotation = BaseRotation;
            }

            //Time corrected move. Moves PacMan By PacManDiv every Second
            this.Loc = this.Loc + ((this.Dir * tempSpeed * (time / 1000)));      //Simple Move PacMan by PacManDir
        }

        /// <summary>
        /// Keeps pac man on screen
        /// </summary>
        /// Credit: Jeff Meyers
        public void UpdateKeepPacmanOnScreen(GraphicsDevice graphics)
        {
            //Keep PacMan On Screen
            if (
                //X right
                (this.Loc.X >
                    graphics.Viewport.Width - this.SpriteTexture.Width)
                ||
                //X left
                (this.Loc.X < 0)
                )
            {
                //Negate X
                this.Dir = this.Dir * new Vector2(-1, 1);
            }
        }

        public void UpdatePacManState()
        {
            inputKeyboard.Update();
            if (inputKeyboard.IsHoldingKey(Keys.LeftShift))
            {
                CurrentState = PacManState.Running;
            }
            else if (inputKeyboard.IsHoldingKey(Keys.Space))
            {
                CurrentState = PacManState.Spinning;
            }
            else
            {
                CurrentState = PacManState.Regular;
            }
        }

        public void UpdateInputFromKeyboard()
        {
            inputKeyboard.Update();
            if (inputKeyboard.IsHoldingKey(UpKey))
            {
                Dir = new Vector2(0, -1);
                BaseRotation = 270;
            }
            if (inputKeyboard.IsHoldingKey(DownKey))
            {
                Dir = new Vector2(0, 1);
                BaseRotation = 90;
            }
            if (inputKeyboard.IsHoldingKey(RightKey))
            {
                Dir = new Vector2(1, 0);
                BaseRotation = 0;
            }
            if (inputKeyboard.IsHoldingKey(LeftKey))
            {
                Dir = new Vector2(-1, 0);
                BaseRotation = 180;
            }
        }
    }
}
