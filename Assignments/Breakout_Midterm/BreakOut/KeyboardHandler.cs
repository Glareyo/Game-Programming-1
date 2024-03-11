﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

//Credit: Jeff Meyers
// Provided lecture and course materials
// Base Code copied from Jeff Meyer's SimpleMovementJump

namespace BreakOut
{
    public static class KeyboardHandler
    {

        static private KeyboardState prevKeyboardState;
        static private KeyboardState keyboardState;


        static public bool IsKeyDown(Keys key)
        {
            return (keyboardState.IsKeyDown(key));
        }

        static public bool IsHoldingKey(Keys key)
        {
            return(keyboardState.IsKeyDown(key) && prevKeyboardState.IsKeyDown(key));
        }

        static public bool WasKeyPressed(Keys key)
        {
            return (keyboardState.IsKeyDown(key) && prevKeyboardState.IsKeyUp(key));
        }

        static public bool HasReleasedKey(Keys key)
        {
            return (keyboardState.IsKeyUp(key) && prevKeyboardState.IsKeyDown(key));
        }

        static public void Update()
        {
            //set our previous state to our new state
            prevKeyboardState = keyboardState;

            //get our new state
            keyboardState = Keyboard.GetState();
        }

        static public bool WasAnyKeyPressed()
        {
            Keys[] keysPressed = keyboardState.GetPressedKeys();

            if (keysPressed.Length > 0)
            {
                foreach (Keys k in keysPressed)
                {
                    if (prevKeyboardState.IsKeyUp(k))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
