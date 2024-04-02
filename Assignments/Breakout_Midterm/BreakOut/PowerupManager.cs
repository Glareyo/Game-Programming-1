using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BreakOut
{
    public class PowerupManager : GameComponent
    {
        //List of Blocks
        //public List<MonogameBlock> Blocks { get; private set; }
        public List<Powerup> Powerups { get; private set; }



        //Interval Times for certain actions
        int SpawnInterval = 180;

        //Current Time before initializing blocks
        int CurrentSpawnInterval = 60;

        Random random;
        Viewport vp;

        public PowerupManager(Game game) : base(game)
        {
            //Blocks = new List<MonogameBlock>();

            Powerups = new List<Powerup>();
            vp = game.GraphicsDevice.Viewport;
            random = new Random();
        }



        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentSpawnInterval -= 1;

            if (CurrentSpawnInterval <= 0)
            {
                CurrentSpawnInterval = SpawnInterval;
                GeneratePowerUp();
            }

            base.Update(gameTime);
        }

        public void PowerupIsHit(Powerup targetPowerUp)
        {
            targetPowerUp.Hit();
        }

        void GeneratePowerUp()
        {
            Powerup p = new Powerup(Game);
            p.Location = new Vector2(random.Next(15,vp.Width-15), random.Next(15,vp.Height/2));
            p.Type = PowerUpType.Duplicate;
            //p.Type = GenerateType();
            
            Powerups.Add(p);
            Game.Components.Add(p);
        }
        PowerUpType GenerateType()
        {
            int index = random.Next(0,2);
            switch (index)
            {
                case 0:
                    return PowerUpType.Duplicate;
                    break;
                case 1:
                    return PowerUpType.Explode;
                    break;
                case 2:
                    return PowerUpType.TripleClone;
                    break;
            }

            return PowerUpType.Duplicate;
        }

        public void ClearComponents()
        {
            foreach(Powerup p in Powerups)
            {
                p.RemoveSelf();
            }
        }
    }
}
