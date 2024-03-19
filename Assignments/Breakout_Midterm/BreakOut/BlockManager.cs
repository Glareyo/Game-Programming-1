using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{
    public class BlockManager : GameComponent
    {
        //List of Blocks
        //public List<MonogameBlock> Blocks { get; private set; }
        public List<Invader> Invaders { get; private set; }


        Texture2D BlockTexture;

        //Interval Times for certain actions
        int SpawnInterval = 180;
        
        //Current Time before initializing blocks
        int CurrentSpawnInterval = 60;

        float BlockSpeed;
        Random random;
        Viewport vp;

        public BlockManager(Game game) : base(game)
        {
            //Blocks = new List<MonogameBlock>();

            Invaders = new List<Invader>();
            vp = game.GraphicsDevice.Viewport;
            random = new Random();
            BlockSpeed = 0.01f;
        }



        public override void Initialize()
        {
            BlockTexture = Game.Content.Load<Texture2D>("block_blue");
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            CurrentSpawnInterval -= 1;

            if (CurrentSpawnInterval <= 0)
            {
                CurrentSpawnInterval = SpawnInterval;
                GenerateBlock();
            }
            MoveBlocks(gameTime);

            base.Update(gameTime);
        }

        public void BlockIsHit(MonogameBlock targetBlock)
        {
            targetBlock.Hit();
        }

        void MoveBlocks(GameTime gameTime)
        {
            foreach(Invader invader in Invaders)
            {
                invader.Move(BlockSpeed, gameTime);
            }
        }

        void GenerateBlock()
        {
            Invader block = new Invader(Game);
            block.Location = new Vector2(random.Next(0,vp.Width),0 - BlockTexture.Height);

            Invaders.Add(block);
            Game.Components.Add(block);
        }
    }
}
