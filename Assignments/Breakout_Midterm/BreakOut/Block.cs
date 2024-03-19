//Credit:
//Jeff Meyers
//Provided classes, codes, and lecture on monogame.
//Class from Jeff Meyers's Examples

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public enum BlockState { Normal, Hit, Broken }

    public class Block
    {
        protected int hitCount; //Future use maybe should change state?
        protected uint blockID;

        protected static uint blockCount;

        public BlockState BlockState { get; set; }

        public Block()
        {
            this.BlockState = BlockState.Normal;
            blockCount++;
            this.blockID = blockCount;
            hitCount = 0;
        }

        public virtual void Hit()
        {
            /*if (BlockState == BlockState.Normal)
            {
                BlockState = BlockState.Hit;
            }
            else if (BlockState == BlockState.Hit)
            {
                BlockState = BlockState.Broken;
            }*/
        }

        public virtual void UpdateBlockState()
        {
            switch (this.BlockState)
            {
                case BlockState.Normal:
                    this.BlockState = BlockState.Hit;
                    break;
                case BlockState.Hit:
                    this.BlockState = BlockState.Broken;
                    break;
            }
        }
    }

    public class MonogameBlock : DrawableSprite
    {
        protected Block block;

        protected string NormalTextureName, HitTextureName;
        protected Texture2D NormalTexture, HitTexture;

        private BlockState blockstate;
        public BlockState BlockState
        {
            get { return this.block.BlockState = this.blockstate; } //encapulsate block.BlockState
            set { this.block.BlockState = this.blockstate = value; }
        }

        public MonogameBlock(Game game)
        : base(game)
        {
            this.block = new Block();
            NormalTextureName = "ufoFrames/ufoF1";
            HitTextureName = "block_bubble";
        }

        protected virtual void updateBlockTexture()
        {
            switch (this.BlockState)
            {
                case BlockState.Normal:
                    this.Visible = true;
                    this.spriteTexture = NormalTexture;
                    break;
                case BlockState.Hit:
                    this.spriteTexture = HitTexture;
                    break;
                case BlockState.Broken:
                    RemoveSelf();
                    break;
            }
        }

        protected override void LoadContent()
        {
            this.NormalTexture = this.Game.Content.Load<Texture2D>(NormalTextureName);
            this.HitTexture = this.Game.Content.Load<Texture2D>(HitTextureName);
            updateBlockTexture(); //notice this is in loadcontent not the constuctor
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            UnityBlockUpdate();
        }

        protected virtual void UnityBlockUpdate()
        {
            updateBlockTexture();
        }

        public virtual void Hit()
        {
            if (this.BlockState == BlockState.Normal)
            {
                this.BlockState = BlockState.Hit;
            }
            else if (this.BlockState == BlockState.Hit)
            {
                this.BlockState = BlockState.Broken;
            }
            updateBlockTexture();
        }

        public void Move(float speed, GameTime gameTime)
        {
            Location.Y += speed * gameTime.ElapsedGameTime.Milliseconds;
        }

        public void RemoveSelf()
        {
            Game.Components.Remove(this);
        }
    }
}
