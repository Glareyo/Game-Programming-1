using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut.Levels
{
    public class Level : GameComponent
    {
        public List<IGameComponent> LevelComponents;
        //public SpriteBatch sb;

        public enum State { Enabled, Disabled }
        public State LevelState { get; private set; }

        public Level(Game game) : base(game)
        {
            LevelState = State.Disabled;
            LevelComponents = new List<IGameComponent>();
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void DisposeLevel()
        {
            Game.Components.Clear();
        }
        public virtual void StartLevel()
        {
            LevelState = State.Enabled;

            foreach (IGameComponent component in LevelComponents)
            {
                Game.Components.Add(component);
            }
        }
    }
}
