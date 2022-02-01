using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class Tail : GameObject
    {
        public Tail(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = 10;
            id = world.score;
        }

        public override void Update()
        {
            previousX = x;
            previousY = y;

            if (id == 1)
            {
                GameObject nextTail = world.gameObjects.Find(obj => obj is Player);
                if (nextTail != null)
                {
                    x = nextTail.previousX;
                    y = nextTail.previousY;
                }
            }
            else
            {
                GameObject nextTail = world.gameObjects.Find(obj => obj.id == id - 1 && obj is Tail);
                if (nextTail != null)
                {
                    x = nextTail.previousX;
                    y = nextTail.previousY;
                }
            }
        }
    }
}
