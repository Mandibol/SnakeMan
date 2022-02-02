using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{   
    internal abstract class Position
    {
       
        public int x;
        public int y;
        ///<summary> 
        ///The basis for the coordinate system for the Objects in the GameWorld
        ///</summary>

        /// <param name="X"> The X-Coordinate</param>
        /// <param name="Y"> The Y-Coordinate</param>
        public Position(int X, int Y) 
        {
            this.x = X;
            this.y = Y;
        }
    }
}
