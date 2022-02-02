using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    /// <summary>
    /// Tail objects follow in a line behind the Player object
    /// </summary>
    internal class Tail : GameObject
    {
        /// <summary>
        /// Set the apperance, starting position and gives a reference to the gameworld.
        /// </summary>
        /// <param name="appearance">A string of chars to represent the Gameobjects, when rendered</param>
        /// <param name="x">The initial X position the GameObject in the GameWorld </param>
        /// <param name="y">The initial Y position the GameObject in the GameWorld </param>
        /// <param name="world"> Refrence to the Gameworld, for access to variables</param>
        public Tail(string appearance, int x, int y, GameWorld world) : base(appearance, x, y, world)
        {
            color = 10;
            id = world.score;
        }
       
        public override void Update()
        {
            previousX = x;
            previousY = y;

            // Makes so the firt tail gets the players previous coordinates.
            // And the tails created follows the previous tail in the lead.
            if (id == 1)
            {
                GameObject nextTail = world.gameObjects.Find(obj => obj is Player);
                if (nextTail != null)
                {
                    x = nextTail.previousX;
                    y = nextTail.previousY;
                }
            }
            else
            {
                GameObject nextTail = world.gameObjects.Find(obj => obj.id == id - 1 && obj is Tail);
                if (nextTail != null)
                {
                    x = nextTail.previousX;
                    y = nextTail.previousY;
                }
            }
        }
    }
}
