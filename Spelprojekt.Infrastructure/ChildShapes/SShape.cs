﻿using TetrisUI;

namespace Spelprojekt
{
    public class SShape : Shape
    {
        public SShape() : base(ShapeColor.Green, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[1, 0] = true;
            ShapeGrid[2, 0] = true;
            ShapeGrid[0, 1] = true;
            ShapeGrid[1, 1] = true;


        }

    }
}