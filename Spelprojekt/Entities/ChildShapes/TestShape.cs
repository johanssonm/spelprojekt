using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class TestShape : Shape
    {
        public TestShape() : base(ShapeColor.Purple, true)
        {
            ShapeGridArea = new bool[2, 2];

            ShapeGridArea[0, 0] = true;
            ShapeGridArea[0, 1] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[1, 0] = true;

            CanBeRotated = false;


        }
    }
}