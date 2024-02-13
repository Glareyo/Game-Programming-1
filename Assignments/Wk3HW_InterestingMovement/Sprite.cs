using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

//Credit: Jeff Meyers
// Provided lecture and course materials
// Base Code copied from Jeff Meyer's SimpleMovementJump

namespace Wk3HW_InterestingMovement
{
    public class Sprite //: ISprite
    {
        Game game;

        string debugString = "";
        
        public string TextureName { get; set; }
        public Texture2D SpriteTexture;
        public Color TextureColor;

        public Vector2 Loc;
        public Vector2 Dir;
        public float SpeedMax;

        public Vector2 Origin;
        public float Rotation;
        GameTime time;

        public Sprite(Game _game)
        {
            game = _game;
            SpeedMax = 200;
            TextureColor = Color.White;
        }
        /// <summary>
        /// Creates a Sprite with set textures.
        /// </summary>
        /// <param name="_textureName"></param>
        /// <param name="_textureColor"></param>
        public Sprite(Game _game, string _textureName, Color _textureColor)
        {
            game = _game;
            TextureName = _textureName;
            TextureColor = _textureColor;
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(SpriteTexture, Loc, TextureColor);
            
            //Credit: Jeff Meyer, provided code / github on rotations
            _spriteBatch.Draw(SpriteTexture,
                new Rectangle( //Draws the collision rectangle, from start point of location to end point of texture size
                    (int)this.Loc.X, 
                    (int)this.Loc.Y, 
                    (int)this.SpriteTexture.Width, 
                    (int)this.SpriteTexture.Height),
                null, //Source Rectangle => Unknown
                TextureColor, //Color
                MathHelper.ToRadians(this.Rotation), //Rotates
                this.Origin, //The origin of the sprite
                SpriteEffects.None, //Sprite Effects
                0 
                );
        }
        public virtual void LoadContent(GraphicsDevice graphics)
        {
            SpriteTexture = game.Content.Load<Texture2D>(TextureName);
            Loc = new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2);
            Origin = new Vector2(SpriteTexture.Width / 2, SpriteTexture.Height / 2);
        }
        public virtual void Update()
        {
        }
    }
}
