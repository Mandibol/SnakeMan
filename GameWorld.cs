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
        public readonly int marginLeft = 1; // MarginLeft Outside the playing area
        public readonly int marginRight = 1; //MarginRight  Outside the playing area
        public readonly int marginTop = 3; //marginTop Outside the playing area
        public readonly int marginDown = 1; //marginDown Outside the playing area
        public int score;
        public bool running = true;

        /// <summary> 
        /// Set the size of the display 
        /// </summary>
        ///  <param name = "width"> Display width</param>
        ///  <param name = "height">Display Height</param>
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
