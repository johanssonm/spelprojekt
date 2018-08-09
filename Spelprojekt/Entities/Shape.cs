using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Build.Framework;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt
{

    public abstract class Shape
    {
        public int ID { get; set; }
        public bool InPlay { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public List<Block> Blocks { get; set; }
        public Rotation RotationState { get; set; } // TODO: Behövs denna?
        public ShapeColor ShapeColor { get; set; }

        public enum Rotation
        {
            Default,
            Left,
            Down,
            Right
        }

        protected Shape(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}