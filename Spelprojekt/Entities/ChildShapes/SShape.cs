using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class SShape : Shape
    {
        public SShape() : base(ShapeColor.Green, true)
        {
            ShapeGridArea = new bool[3, 3];

            ShapeGridArea[1, 0] = true;
            ShapeGridArea[2, 0] = true;
            ShapeGridArea[0, 1] = true;
            ShapeGridArea[1, 1] = true;


        }

    }
}