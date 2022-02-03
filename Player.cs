using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    /// <summary>
    /// The Head of the snake controlled by the player
    /// </summary>
    internal class Player : GameObject
    {
        /// <param name="world"> We are using World for reference in gameWorld, in this class(player) we check for collison </param>
        public Player(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = ConsoleColor.Green;
        }
        
        /// <summary>
        /// The <see cref="Player"/> objects direction
        /// </summary>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        public Direction facing = Direction.Up; //Set the Snakes Starting Direction 
       
        public override void Update()
        {
            //Remember Previous Position
            previousX = x;
            previousY = y;

            // Control the Inputs and changed the direction accordingly.
            // Also makes sure that we are unable to go into a opposite direction into our own tail and end the game.
            switch (Program.key)
            {

                case ConsoleKey.LeftArrow:
                    if (facing != Direction.Right)
                    {
                        facing = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (facing != Direction.Left)
                    {
                        facing = Direction.Right;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (facing != Direction.Down)
                    {
                        facing = Direction.Up;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (facing != Direction.Up)
                    {
                        facing = Direction.Down;
                    }
                    break;
            }

            //Move the Player object one step i the direction it is facing
            switch (facing)
            {
                
                case Direction.Left:
                    x-= 1;
                    break;
                case Direction.Right:  
                    x+=1;
                    break;
                case Direction.Up:
                    y-=1;
                    break;
                case Direction.Down:
                    y+=1;
                    break;
            }

            // If player position is larger or smaller than GameWorld.width or GameWorld.height
            // then wrap player position
            if (x < 0)
            {
                x = world.width - 1;
            }
            else if (x >= world.width)
            {
                x = 0;
            }

            else if (y < 0)
            {
                y = world.height - 1;
            }
            else if (y >= world.height)
            {
                y = 0;
            }

            // Checks GameWorld.gameObjects list for any Foo that shares same position as this object.
            // If any is found it ends the Program.Loop wich ends the game 
            GameObject collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Tail);
            if (collison != null)
            {
                world.running = false;
            }

            // Checks GameWorld.gameObjects list for the first Food that shares same position as this object.
            // If any is found increase GameWorld.score and Program.frameRate and create a new Tail. 
            collison = world.gameObjects.Find(obj => obj.x == x && obj.y == y && obj is Food);
            if (collison != null)
            {
                world.score++;
                world.frameRate = 10 + world.score / 3;
                //Create a new Tail
                Tail tail = new("██", previousX, previousY, world);
                world.gameObjects.Add(tail);
            }
        }
    }
}
