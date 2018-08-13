using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class TShape : Shape
    {
        public TShape() : base(ShapeColor.Purple, true)
        {
            ShapeGridArea = new bool[3, 3];

            ShapeGridArea[1, 0] = true;
            ShapeGridArea[0, 1] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[2, 1] = true;


        }
    }
}