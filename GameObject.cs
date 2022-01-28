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
        public char appearance;

        public GameObject(char appearance, int x, int y) : base(x, y)
        {
            this.appearance = appearance;
        }
        public abstract void Update();
    }
}
