using TetrisUI;

namespace Spelprojekt
{
    public class LShape : Shape
    {
        public LShape() : base(ShapeColor.Orange, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[2, 0] = true;
            ShapeGrid[2, 1] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[0, 1] = true;


        }

    }
}