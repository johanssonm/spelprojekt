using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class ZShape : Shape
    {
        public ZShape() : base(ShapeColor.Red, true)
        {
            ShapeGridArea = new bool[3, 3];

            ShapeGridArea[0, 0] = true;
            ShapeGridArea[1, 0] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[2, 1] = true;


        }

    }
}