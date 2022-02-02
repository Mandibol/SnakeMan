using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    /// <summary> 
    /// The Game world object is responsible for keeping a list of all instances of GameObjects
    /// And running the update 
    /// </summary>
    internal class GameWorld
    {
        public int width;
        public int height;
        public int score;

        /// <summary> 
        /// He have to write here 
        /// </summary>
        ///  <param name = "width"> BLA BLA BLA</param>
        ///  <param name = "height">Hej</param>
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
