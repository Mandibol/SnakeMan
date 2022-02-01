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
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }
        }
    }
}
