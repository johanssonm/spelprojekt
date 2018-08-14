using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class ZShape : Shape
    {
        public ZShape() : base(ShapeColor.Red, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[0, 0] = true;
            ShapeGrid[1, 0] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;


        }

    }
}