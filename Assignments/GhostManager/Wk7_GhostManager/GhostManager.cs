using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Network.Client;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wk7_GhostManager
{
    public class GhostManager : GameComponent
    {
        List<Ghost> Ghosts;
        SpriteBatch sb;
        Random random;

        public GhostManager(Game game) : base(game)
        {
            sb = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Initialize()
        {
            //Create ghost list
            Ghosts = new List<Ghost>();
            Ghosts.Add(new Ghost(Game, "blueGhost"));
            Ghosts.Add(new Ghost(Game, "redGhost"));
            Ghosts.Add(new Ghost(Game, "orangeGhost"));
            Ghosts.Add(new Ghost(Game, "pinkGhost"));

            random = new Random();

            foreach(Ghost ghost in Ghosts)
            {
                Game.Components.Add(ghost);
                ghost.Location = new Vector2(random.Next(0,Game.GraphicsDevice.Viewport.Width), random.Next(0, Game.GraphicsDevice.Viewport.Height));

                Vector2 direction = new Vector2(random.Next(-1, 1), random.Next(-1, 1));
                if (direction == Vector2.Zero)
                {
                    direction.X = 1;
                }

                ghost.Direction = direction;
            }

            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (Ghost ghost in Ghosts)
            {
                foreach(Ghost ghost2 in Ghosts)
                {
                    if (ghost !=ghost2 && ghost.Intersects(ghost2))
                    {
                        moveGhost(ghost, ghost2);
                    }
                }
            }

            base.Update(gameTime);
        }

        public void moveGhost(Ghost ghost1, Ghost ghost2)
        {
            //ghost1.Direction.X *= -1;
            //ghost1.Direction.Y *= -1;
            //ghost2.Direction.X *= -1;
            //ghost2.Direction.Y *= -1;
            ghost1.Direction = new Vector2(random.Next(-1, 1), random.Next(-1, 1));
            ghost2.Direction = new Vector2(random.Next(-1, 1), random.Next(-1, 1));
        }
    }
}
