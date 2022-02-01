using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class Player : GameObject
    {
 
        public Player(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = 10;
        }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        public Direction direction = Direction.Left;


        public override void Update()
        {
            previousX = x;
            previousY = y;

            switch (direction)
            {
                case Direction.Left:
                    x-= 1;
                    break;
                case Direction.Right:  
                    x+=1;
                    break;
                case Direction.Up:
                    y-=1;
                    break;
                case Direction.Down:
                    y+=1;
                    break;
            }

            // Out of bounds Check
            if (x < 0)
            {
                x = Program.worldWidth-1;
            }
            else if (x >= Program.worldWidth) 
            {
                x = 0;
            }

            else if (y < 0)
            {
                y = Program.worldHeight-1;
            }
            else if (y >= Program.worldHeight)
            {
                y = 0;
            }

            // Collision Check food, svar : object food or null
            GameObject collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Food);
            if (collison != null)
            {
                world.score++;
                //Add Tail
                Tail tail = new Tail("██", previousX, previousY, world);
                world.gameObjects.Add(tail);
            }

            // Collision Check Tail
            collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Tail);
            if (collison != null)
            {
                Program.running = false;
            }
        }
    }
}
