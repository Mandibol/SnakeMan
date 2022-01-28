using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal abstract class Position
    {
        public int x;
        public int y;

        public Position(int X, int Y) 
        {
            this.x = X;
            this.y = Y;
        }
    }
}
