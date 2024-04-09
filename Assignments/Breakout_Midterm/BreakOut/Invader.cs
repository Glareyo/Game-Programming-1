using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BreakOut.Ball;

namespace BreakOut
{
    public class Invader : MonogameBlock
    {
        float animInterval;
        float targetAnimIntervalChange;

        public bool invaderSucceeded;

        int currentFrame;

        List<Texture2D> NormalTextures;
        List<Texture2D> HitTextures;
        List<Texture2D> ExplodeTextures;

        List<Texture2D> TargetTextures;

        public Invader(Game game) : base(game)
        {
            animInterval = 0;
            targetAnimIntervalChange = 120;
            currentFrame = 0;
            invaderSucceeded = false;
        }
        public override void Initialize()
        {
            NormalTextures = new List<Texture2D>();
            HitTextures = new List<Texture2D>();
            ExplodeTextures = new List<Texture2D>();


            base.Initialize();
        }
        protected override void LoadContent()
        {
            var gc = Game.Content;

            this.SpriteTexture = gc.Load<Texture2D>("ufoFrames/ufoF1");

            NormalTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoF1"));
            NormalTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoF2"));
            NormalTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoF3"));
            NormalTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoF4"));

            HitTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoDamaged/ufoDmgF1"));
            HitTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoDamaged/ufoDmgF2"));
            HitTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoDamaged/ufoDmgF3"));
            HitTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoDamaged/ufoDmgF4"));

            ExplodeTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoExplode/ufoExplodeF1"));
            ExplodeTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoExplode/ufoExplodeF2"));
            ExplodeTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoExplode/ufoExplodeF3"));
            ExplodeTextures.Add(gc.Load<Texture2D>("ufoFrames/ufoExplode/ufoExplodeF4"));

            TargetTextures = NormalTextures;

            base.LoadContent();

            //Center the origin
            this.Origin = new Vector2(SpriteTexture.Width / 2, SpriteTexture.Height / 2);
        }
        public override void Update(GameTime gameTime)
        {
            //Rotate += 1f;
            base.Update(gameTime);

            ChangeFrame(gameTime);

            //bottom Miss
            if (this.Location.Y + this.spriteTexture.Height > this.Game.GraphicsDevice.Viewport.Height)
            {
                invaderSucceeded = true;
            }
        }

        void ChangeFrame(GameTime gameTime)
        {
            animInterval += gameTime.TotalGameTime.Milliseconds;
            if (animInterval >= targetAnimIntervalChange) 
            {
                //Increase frame index
                currentFrame++;
                if (currentFrame >= TargetTextures.Count)
                {//Reset to index frame
                    if (this.BlockState == BlockState.Broken)
                    {
                        RemoveSelf();
                    }
                    currentFrame = 0;
                }
                animInterval = 0;
                this.SpriteTexture = TargetTextures[currentFrame];
            }
        }

        public override void Hit()
        {
            animInterval = 0;
            currentFrame = 0;
            base.Hit();
        }

        protected override void updateBlockTexture()
        {
            switch (this.BlockState)
            {
                case BlockState.Normal:
                    this.Visible = true;
                    this.TargetTextures = NormalTextures;
                    break;
                case BlockState.Hit:
                    this.TargetTextures = HitTextures;
                    break;
                case BlockState.Broken:
                    this.TargetTextures = ExplodeTextures;
                    break;
            }
        }
    }
}
