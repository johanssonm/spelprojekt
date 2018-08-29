using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public class testShape : Shape, IShape
    {
        public testShape() : base(ShapeColor.Purple, true)
        {
            ShapeGrid = new bool[,]
            {
                {true, true, true},
                {false, true, false},
                {false, true, false},
                {false, true, false},

            };

            GameGridXPosition = 1;
            GameGridXPosition = 1;



        }
    }
}