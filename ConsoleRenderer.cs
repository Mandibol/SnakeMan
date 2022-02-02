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
        public ConsoleRenderer(GameWorld gameWorld)
        {
            
            // Configs the Console-Windows to the size set.

            world = gameWorld;
            Console.SetWindowSize(world.width, world.height);
            Console.CursorVisible = false;
           
            // For-loop for rendering out background and the HUD.
            for (int y = 0; y < world.height; y++)
            {
                for (int x = 0; x < world.width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == Program.displayWidth/2 - 4 && y == 1) { Console.Write("SNAKEMAN"); }
                    else if (x == 0 && y == 0) { Console.Write("╔"); }
                    else if (x == world.width - 1 && y == 0) { Console.Write("╗"); }
                    else if (x == 0 && y == 2) { Console.Write("╠"); }
                    else if (x == world.width - 1 && y == 2) { Console.Write("╣"); }
                    else if (x == 0 && y == world.height - 1) { Console.Write("╚"); }
                    else if (x == world.width - 1 && y == world.height - 1) { Console.Write("╝"); }
                    else if (y == world.height - 1 || y == 0 || y == 2) { Console.Write("═"); }
                    else if (x == 0 || x == world.width - 1) { Console.Write("║"); }
                }
            }
        }
        /// <summary>
        /// Loops through all instances of <see cref="GameObject"/> and Writes over them with Blank
        /// </summary>
        public void RenderBlank()
        {
            //Clear GameObjects
            foreach (var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x * 2 + Program.marginLeft, gameObject.y + Program.marginTop);
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
                Console.ForegroundColor = (ConsoleColor)gameObject.color;
                Console.SetCursorPosition(gameObject.x * 2 + Program.marginLeft, gameObject.y + Program.marginTop);
                Console.Write(gameObject.appearance);
            }
            //Render Score
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: " + world.score);
            //Render Speed
            Console.SetCursorPosition(Program.displayWidth - 10 , 1);
            Console.Write("Speed: " + Program.frameRate);
        }
    }
}
