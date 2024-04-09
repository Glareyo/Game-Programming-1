using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut
{

    public enum InvaderManagerState { Running, OutOfInvaders, InvaderSucceeded }
    public class InvaderManager : GameComponent
    {
        //List of Blocks
        //public List<MonogameBlock> Blocks { get; private set; }
        public List<Invader> Invaders { get; private set; }
        public InvaderManagerState State { get; private set; }

        int numOfSmallInvaders;
        int numOfLargeInvaders;

        Texture2D BlockTexture;

        //Interval Times for certain actions
        int SpawnInterval = 180;
        
        //Current Time before initializing blocks
        int CurrentSpawnInterval = 60;

        float InvaderSpeed;
        Random random;
        Viewport vp;

        public InvaderManager(Game game) : base(game)
        {
            numOfSmallInvaders = 0;
            numOfLargeInvaders = 0;

            State = InvaderManagerState.Running;

            Invaders = new List<Invader>();
            vp = game.GraphicsDevice.Viewport;
            random = new Random();
        }
        public InvaderManager(Game game, int _numOfSmallInvaders, int _numOfLargeInvaders) : base(game)
        {
            numOfSmallInvaders = _numOfSmallInvaders;
            numOfLargeInvaders = _numOfLargeInvaders;

            State = InvaderManagerState.Running;

            Invaders = new List<Invader>();
            vp = game.GraphicsDevice.Viewport;
            random = new Random();
        }



        public override void Initialize()
        {
            InvaderSpeed = 0.01f;
            BlockTexture = Game.Content.Load<Texture2D>("block_blue");
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            //Change to status of the Manager to reveal if all invaders are destroyed.
            if (NoMoreInvadersSpawning() && AllCurrentInvadersDestroyed())
            {
                State = InvaderManagerState.OutOfInvaders;
            }
            else if (InvaderHasSucceededPastPlayer())
            {
                State = InvaderManagerState.InvaderSucceeded;
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
                invader.Move(InvaderSpeed, gameTime);
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

        bool InvaderHasSucceededPastPlayer()
        {
            foreach(Invader invader in Invaders)
            {
                if (invader.invaderSucceeded)
                {
                    return true;
                }
            }
            return false;
        }

        public void ClearComponents()
        {
            foreach(Invader invader in Invaders)
            {
                Game.Components.Remove(invader);
            }
        }
    }
}
