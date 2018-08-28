using Infrastructure.Entities;
using TetrisUI;

namespace Spelprojekt
{
    public class iShape : Shape, IShape
    {
        public iShape() : base(ShapeColor.Cyan, true)
        {
            ShapeGrid = new bool[4, 4];

            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;
            ShapeGrid[3, 1] = true;
            ShapeGrid[0, 1] = true;
        }

    }
}