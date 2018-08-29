using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{

    public abstract class Shape : IShape
    {
        public int Id { get; set; }
        public bool IsInPlay { get; set; }
        public string Name { get; set; }
        public bool CanBeRotated { get; set; }
        public bool[,] ShapeGrid { get; set; }

        public int GameGridXPosition { get; set; }
        public int GameGridYPosition { get; set; }

        public ShapeColor ShapeColor { get; set; }

        protected Shape(ShapeColor shapecolor, bool canBeRotated)
        {
            
            ShapeColor = shapecolor;
            CanBeRotated = canBeRotated;
            GameGridXPosition = 3;
            GameGridYPosition = 0;

        }

        protected Shape()
        {
        }
    }
}