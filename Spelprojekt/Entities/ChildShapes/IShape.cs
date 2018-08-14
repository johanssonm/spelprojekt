using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class IShape : Shape
    {
        public IShape() : base(ShapeColor.Green, true)
        {
            ShapeGrid = new bool[4, 4];

            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;
            ShapeGrid[3, 1] = true;
            ShapeGrid[0, 1] = true;


        }

    }
}