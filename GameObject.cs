using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal abstract class GameObject : Position
    {
        // TODO
        public string appearance;
        public GameWorld world;
        public int color;
        public int id;
        public int previousX;
        public int previousY;


        public GameObject(string appearance, int x, int y, GameWorld World) : base(x, y)
        {
            this.appearance = appearance;
            world = World;
        }
        public abstract void Update();
    }
}
