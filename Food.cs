using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class Food : GameObject
    {
        public Food(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = 12;
        }

        public override void Update()
        {
            // Collision with player
            GameObject collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Player);
            if (collison != null)
            {
                //check empty
                int testX;
                int testY;
                do
                {
                    var rand = new Random();
                    testX = (int)rand.Next(0, Program.worldWidth);
                    testY = (int)rand.Next(0, Program.worldHeight);
                    collison = world.gameObjects.Find(obj => obj.x == testX && obj.y == testY);
                }
                while (collison != null);

                x = testX;
                y = testY;
            }
        }
    }
}
