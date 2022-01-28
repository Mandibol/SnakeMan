using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class GameWorld
    {
        public int width;
        public int height;
        public int score;

        public GameWorld(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public List<GameObject> gameObjects = new List<GameObject>();
        public void Update()
        {
            int playerX = 0;
            int playerY = 0;

            foreach (var gameObject in gameObjects)
            {
                gameObject.Update();

                if (gameObject is Player)
                {
                    playerX = gameObject.x;
                    playerY = gameObject.y;
                }
                
                if (gameObject is Food && gameObject.x == playerX && gameObject.y == playerY)
                {
                    score++;
                    var rand = new Random();
                    gameObject.x = (int)rand.Next(1, Console.WindowWidth);
                    gameObject.y = (int)rand.Next(1, Console.WindowHeight);
                }
  
            }
        }
    }
}
