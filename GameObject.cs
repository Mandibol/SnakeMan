using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
   
    /// <summary>
    /// The GameObject is the parent class for Player,Tail and food. 
    /// </summary> 
    internal abstract class GameObject : Position
    {
     
        public string appearance; // A string of chars to represent the Gameobjects, when rendered
        public GameWorld world; // reference to GameWorld
        public ConsoleColor color; // Coloring the representing char, such as Snake or Food
        public int id; // ID is used for identifying Tail, or food or other gameobjects
        public int previousX; // Previous x coordinate for gameObject
        public int previousY; // Previous y coordinate for gameObject

        /// <summary>
        /// Set the apperance, starting position and gives a reference to the gameworld.
        /// </summary>
        /// <param name="appearance">A string of chars to represent the Gameobjects, when rendered</param>
        /// <param name="x">The initial X position the GameObject in the GameWorld </param>
        /// <param name="y">The initial Y position the GameObject in the GameWorld </param>
        /// <param name="World"> Refrence to the Gameworld, for access to variables</param>
        public GameObject(string appearance, int x, int y, GameWorld World) : base(x, y)
        {
            this.appearance = appearance;
            world = World;
        }
        /// <summary>
        /// Run the Code Once every Gameloop
        /// </summary>
        public abstract void Update();
    }
}
