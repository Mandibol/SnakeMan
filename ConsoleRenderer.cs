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
            //Backgrunden och HUD ritas ut.
            for (int y = 0; y < world.height; y++)
            {
                for (int x = 0; x < world.width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 21 && y == 1) { Console.Write("SNAKEMAN"); }
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

        public void RenderBlank()
        {
            foreach (var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x * 2 + Program.marginLeft, gameObject.y + Program.marginTop);
                Console.Write("  ");
            }
        }
        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)


            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
            foreach (var gameObject in world.gameObjects)
            {
                Console.SetCursorPosition(gameObject.x * 2 + Program.marginLeft, gameObject.y + Program.marginTop);
                Console.Write(gameObject.appearance);
            }
            Console.SetCursorPosition(1, 1);
            Console.Write("Score: " + world.score);
        }
    }
}
