using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class OShape : Shape
    {

        public OShape() : base(ShapeColor.Yellow, false)
        {
            ShapeGrid = new bool[4, 3];

            ShapeGrid[1, 0] = true;
            ShapeGrid[2, 0] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;


        }

    }
}