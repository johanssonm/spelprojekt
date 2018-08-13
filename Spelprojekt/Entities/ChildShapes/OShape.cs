using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class OShape : Shape
    {

        public OShape() : base(ShapeColor.Yellow, false)
        {
            ShapeGridArea = new bool[4, 3];

            ShapeGridArea[1, 0] = true;
            ShapeGridArea[2, 0] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[2, 1] = true;


        }

    }
}