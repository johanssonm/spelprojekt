using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public class zShape : Shape, IShape
    {
        public zShape() : base(ShapeColor.Red, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[0, 0] = true;
            ShapeGrid[1, 0] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;
        }
    }
}