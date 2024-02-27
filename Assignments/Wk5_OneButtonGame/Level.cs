using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5_OneButtonGame
{
    public class Level : GameComponent
    {
        public List<IGameComponent> LevelComponents;
        public SpriteBatch sb;

        public Level(Game game) : base(game)
        {
            LevelComponents = new List<IGameComponent>();
        }
        public override void Initialize()
        {
            AddComponents();
            base.Initialize();
        }

        public virtual void DisposeLevel()
        {
            /*foreach (IGameComponent component in LevelComponents)
            {
                Game.Components.Remove(component);
            }
            Game.Components.Remove(this);*/
            Game.Components.Clear();
        }
        public virtual void AddComponents()
        {
            foreach(IGameComponent component in LevelComponents)
            {
                Game.Components.Add(component);
            }
        }
    }
}
