using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class IShape : Shape
    {
        public IShape() : base(ShapeColor.Green, true)
        {
            ShapeGridArea = new bool[4, 4];

            ShapeGridArea[1, 1] = true;
            ShapeGridArea[2, 1] = true;
            ShapeGridArea[3, 1] = true;
            ShapeGridArea[0, 1] = true;


        }

    }
}