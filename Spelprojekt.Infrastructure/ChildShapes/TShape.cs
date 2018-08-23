using TetrisUI;

namespace Spelprojekt
{
    public class TShape : Shape
    {
        public TShape() : base(ShapeColor.Purple, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[1, 0] = true;
            ShapeGrid[0, 1] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;


        }
    }
}