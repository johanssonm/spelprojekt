using TetrisUI;

namespace Spelprojekt
{
    public class JShape : Shape
    {
        public JShape() : base(ShapeColor.Blue, true)
        {
            ShapeGrid = new bool[3, 3];

            ShapeGrid[0, 0] = true;
            ShapeGrid[0, 1] = true;
            ShapeGrid[1, 1] = true;
            ShapeGrid[2, 1] = true;


        }

    }
}