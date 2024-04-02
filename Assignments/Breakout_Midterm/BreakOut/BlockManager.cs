using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{

    public enum BlockManagerState { Running, OutOfInvaders }
    public class BlockManager : GameComponent
    {
        //List of Blocks
        //public List<MonogameBlock> Blocks { get; private set; }
        public List<Invader> Invaders { get; private set; }
        public BlockManagerState State { get; private set; }

        int numOfSmallInvaders;
        int numOfLargeInvaders;

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
            numOfSmallInvaders = 0;
            numOfLargeInvaders = 0;

            State = BlockManagerState.Running;

            Invaders = new List<Invader>();
            vp = game.GraphicsDevice.Viewport;
            random = new Random();
            BlockSpeed = 0.01f;
        }
        public BlockManager(Game game, int _numOfSmallInvaders, int _numOfLargeInvaders) : base(game)
        {
            numOfSmallInvaders = _numOfSmallInvaders;
            numOfLargeInvaders = _numOfLargeInvaders;

            State = BlockManagerState.Running;

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
            //Change to status of the Manager to reveal if all invaders are destroyed.
            if (NoMoreInvadersSpawning() && AllCurrentInvadersDestroyed())
            {
                State = BlockManagerState.OutOfInvaders;
            }
            else
            {
                CurrentSpawnInterval -= 1;

                if (CurrentSpawnInterval <= 0)
                {
                    CurrentSpawnInterval = SpawnInterval;
                    GenerateBlock();
                }
            }
            
            MoveBlocks(gameTime);
            RemoveBrokenBlocks();

            base.Update(gameTime);
        }

        public void BlockIsHit(MonogameBlock targetBlock)
        {
            targetBlock.Hit();
        }

        void RemoveBrokenBlocks()
        {
            for (int i = 0; i < Invaders.Count; i++)
            {
                if (Invaders[i].BlockState == BlockState.Broken) 
                {
                    Invaders.RemoveAt(i);
                    //Backtrack as to not break game
                    i--;
                }
            }
        }

        void MoveBlocks(GameTime gameTime)
        {
            foreach(Invader invader in Invaders)
            {
                invader.Move(BlockSpeed, gameTime);
            }
        }

        /// <summary>
        /// Generate a random Invader on screen
        /// </summary>
        void GenerateBlock()
        {
            if (numOfSmallInvaders > 0 || numOfLargeInvaders > 0) 
            {
                Invader block = RandomlyChooseInvader();
                block.Location = new Vector2(random.Next(0, vp.Width), 0 - BlockTexture.Height);

                Invaders.Add(block);
                Game.Components.Add(block);
            }
        }

        Invader RandomlyChooseInvader()
        {
            if (numOfSmallInvaders > 0 && numOfLargeInvaders > 0)
            {
                int type = random.Next(0, 1);
                if (type == 0)
                {
                    numOfSmallInvaders--;
                    return new Invader(Game);
                }
                else
                {
                    numOfLargeInvaders--;
                    return new Invader(Game);
                }
            }
            else if (numOfSmallInvaders > 0)
            {
                numOfSmallInvaders--;
                return new Invader(Game);
            }
            else //If NumofLargeInvaders > 0
            {
                numOfLargeInvaders--;
                return new Invader(Game);
            }
        }

        /// <summary>
        /// Check to see if there are no more Invaders spawning
        /// </summary>
        /// <returns></returns>
        bool NoMoreInvadersSpawning()
        {
            if (numOfSmallInvaders == 0 && numOfLargeInvaders == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check to see if all invaders that spawned are destroyed
        /// </summary>
        /// <returns></returns>
        bool AllCurrentInvadersDestroyed()
        {
            if (Invaders.Count <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
