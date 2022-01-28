using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMan
{
    internal class Player : GameObject
    {
        public Player(char appearance, int x, int y) : base(appearance, x, y)
        { 
        
        }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        public Direction direction = Direction.Left;


        public override void Update()
        {
            int previousX = x;
            int previousY = y;

            switch (direction)
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

            if (x < 1 || x >= Console.WindowWidth-1)
            {
                x = previousX;
            }
            if (y < 2 || y >= Console.WindowHeight-1)
            {
                y = previousY;
            }
        }
    }
}
