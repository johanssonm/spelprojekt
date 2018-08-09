using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class TestShape : Shape
    {

        public TestShape() : base(2,2)
        {
            var blocks = new List<Block>()
            {
                new Block(0,0,ShapeColor.Green),
                new Block(1,0,ShapeColor.Green),
                new Block(0,1,ShapeColor.Green),
                new Block(1,1,ShapeColor.Blue)
            };

            Blocks = blocks;

            RotationState = Rotation.Default;
        }

    }
}