using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    /// <summary>
    ///  Renders the game on screen
    /// </summary>
    internal class ConsoleRenderer
    {
        private GameWorld world;
        public int displayWidth; // The size of the Window Width
        public int displayHeight;  // The Size of the Window Height

        public ConsoleRenderer(GameWorld gameWorld)
        {
            this.world = gameWorld;
            displayWidth = world.width * 2 + world.marginLeft + world.marginRight;
            displayHeight= world.height + world.marginTop + world.marginDown; 
        }
        /// <summary>
        /// Loops through all instances of <see cref="GameObject"/> and Writes over them with Blank
        /// </summary>
        public void RenderBlank()
        {
            //Clear GameObjects
            foreach (var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x * 2 + world.marginLeft, gameObject.y + world.marginTop);
                Console.Write("  ");
            }
        }
        /// <summary>
        /// Loops through all instances of <see cref="GameObject"/> and Render their apperance on screen in their <see cref="GameObject.color"/>
        /// then renders <see cref="GameWorld.score"/> and Speed(<see cref="Program.frameRate"/>) in the upper corners
        /// </summary>
        public void Render()
        {
            //Render GameObjects
            foreach (var gameObject in world.gameObjects)
            {
                Console.ForegroundColor = gameObject.color;
                Console.SetCursorPosition(gameObject.x * 2 + world.marginLeft, gameObject.y + world.marginTop);
                Console.Write(gameObject.appearance);
            }
            //Render Score
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: " + world.score);
            //Render Speed
            Console.SetCursorPosition(displayWidth - 10 , 1);
            Console.Write("Speed: " + Program.frameRate);
        }
    }
}
