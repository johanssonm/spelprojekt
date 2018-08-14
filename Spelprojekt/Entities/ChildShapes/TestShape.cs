using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class TestShape : Shape
    {
        public TestShape() : base(ShapeColor.Purple, true)
        {
            ShapeGrid = new bool[2, 2];

            ShapeGrid[0, 0] = true;
            ShapeGrid[0, 1] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[1, 0] = true;

            CanBeRotated = false;


        }
    }
}