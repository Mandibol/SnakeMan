using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    /// <summary>
    /// Food works as playerScore and checking collision for gameobject if player collides with food 
    /// </summary>
    internal class Food : GameObject
    {
        /// <param name="appearance">A string of chars to represent the Gameobjects, when rendered</param>
        /// <param name="x">The initial X position the GameObject in the GameWorld </param>
        /// <param name="y">The initial Y position the GameObject in the GameWorld </param>
        /// <param name="world"> Refrence to the Gameworld, for access to variables</param>
        public Food(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = ConsoleColor.Red;
        }
 
        public override void Update()
        {
            // Collision with player
            GameObject collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Player);
            if (collison != null)
            {
                //check for empty space to place food, loops until a valid empty space is found
                int testX;
                int testY;
                int count = 0;
                do
                {
                    count++;
                    var rand = new Random();
                    testX = (int)rand.Next(0, world.width);
                    testY = (int)rand.Next(0, world.height);
                    collison = world.gameObjects.Find(obj => obj.x == testX && obj.y == testY);
                }
                while (collison != null || count > 99);

                x = testX;
                y = testY;
            }
        }
    }
}
