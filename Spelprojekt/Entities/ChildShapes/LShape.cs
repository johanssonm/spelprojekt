﻿using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class LShape : Shape
    {
        public LShape() : base(ShapeColor.Yellow, true)
        {
            ShapeGridArea = new bool[3, 3];

            ShapeGridArea[2, 0] = true;
            ShapeGridArea[2, 1] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[0, 1] = true;


        }

    }
}