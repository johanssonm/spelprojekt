using TetrisUI;

namespace Spelprojekt
{

    public abstract class Shape
    {
        public int ID { get; set; }
        public bool IsInPlay { get; set; }

        public bool CanBeRotated { get; set; }
        public bool[,] ShapeGridArea { get; set; }

        public int GameGridXPosition { get; set; }
        public int GameGridYPosition { get; set; }
        public int CurrentWidth { get; set; }

        public Rotation RotationState { get; set; } // TODO: Behövs denna?
        public ShapeColor ShapeColor { get; set; }

        public enum Rotation
        {
            Default,
            Right,
            Down,
            Left
        }

        protected Shape(ShapeColor shapecolor, bool canBeRotated)
        {

            ShapeColor = shapecolor;
            RotationState = Rotation.Default;
            CanBeRotated = canBeRotated;
            GameGridXPosition = 0;
            GameGridYPosition = 0;

        }
    }
}