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

    public enum LevelState { Enabled, Disabled }

    public class Level : GameComponent
    {
        public List<IGameComponent> LevelComponents;
        public LevelState State { get; set; }

        public Level(Game game) : base(game)
        {
            State = LevelState.Disabled;
            LevelComponents = new List<IGameComponent>();
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void DisposeLevel()
        {
            foreach(IGameComponent componenet in LevelComponents)
            {
                Game.Components.Remove(componenet);
            }
        }

        public void DisableLevel()
        {
            State = LevelState.Disabled;
        }

        public bool IsLevelDisabled()
        {
            if (State == LevelState.Disabled)
            {
                return true;
            }
            return false;
        }

        public virtual void StartLevel()
        {
            State = LevelState.Enabled;

            foreach (IGameComponent component in LevelComponents)
            {
                Game.Components.Add(component);
            }
        }

    }
}
