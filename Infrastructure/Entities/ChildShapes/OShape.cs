using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public class oShape : Shape, IShape
    {

        public oShape() : base(ShapeColor.Yellow, false)
        {
            ShapeGrid = new bool[3, 4];

            ShapeGrid[1, 0] = true;
            ShapeGrid[2, 0] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;


        }

    }
}