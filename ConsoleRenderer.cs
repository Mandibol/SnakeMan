using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

            world = gameWorld;
            Console.SetWindowSize(world.width, world.height);
            Console.CursorVisible = false;
        }

        public void RenderBlank() 
        {
            foreach(var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x, gameObject.y);
                Console.Write(" ");
            }
        }
        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)
            

            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
            foreach (var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x, gameObject.y);
                Console.Write(gameObject.appearance);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(world.score);
        }
    }
}
