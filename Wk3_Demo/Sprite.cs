using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk3_Demo
{
    class Sprite
    {
        protected Texture2D Texture;

        protected Vector2 Orgin;    //Orgin for Drawing
        protected Vector2 Location;      //Sprite location
        protected Vector2 Direction;      //Sprite direction
        protected float Speed;      //speed for the PacMan Sprite in pixels per frame per second
        protected float Rotate;

        public string TextureName { get; set; }

        protected Game game;

        public Sprite(Game game)
        {
            this.game = game;
        }

        public virtual void LoadContent()
        {
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "PacmanSingle";

            Texture = game.Content.Load<Texture2D>(TextureName);
            //Set PacMan Location to center of screen
            Location = new Vector2(game.GraphicsDevice.Viewport.Width / 2,
                game.GraphicsDevice.Viewport.Height / 2);
            //Vector for pacman direction
            //notice this vector has no magnitude it's noramlized
            Direction = new Vector2(1, 0);

            //Orgin shoud be center of texture
            Orgin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            Rotate = 0;

            //Pacman spped 
            Speed = 100;
        }

        float time;

        public virtual void Update(GameTime gameTime)
        {
            //Elapsed time since last update will be used to correct movement speed
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Time corrected move. Moves Sprite By Div every Second
            Location = Location + Direction * Speed * (time / 1000);      //Simple Move PacMan by PacManDir

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rotate += 15;

            spriteBatch.Draw(Texture,  //texture2D
                new Rectangle(        //Create rectange to draw to
                    (int)Location.X,
                    (int)Location.Y,
                    Texture.Width,
                    Texture.Height),
                null,   //no source rectangle
                Color.White,
                MathHelper.ToRadians(Rotate), //rotation in radians
                Orgin,   //0,0 is top left
                SpriteEffects.FlipHorizontally,
                0);

        }
    }
}
