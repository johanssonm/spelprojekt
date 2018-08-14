﻿using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class JShape : Shape
    {
        public JShape() : base(ShapeColor.Blue, true)
        {
            ShapeGridArea = new bool[3, 3];

            ShapeGridArea[0, 0] = true;
            ShapeGridArea[0, 1] = true;
            ShapeGridArea[1, 1] = true;
            ShapeGridArea[2, 1] = true;


        }

    }
}