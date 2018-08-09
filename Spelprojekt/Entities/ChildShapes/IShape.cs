using System.Collections.Generic;
using TetrisUI;

namespace Spelprojekt
{
    public class IShape : Shape
    {
        public IShape() : base(4,4)
        {
            var blocks = new List<Block>()
            {
                new Block(0,0,ShapeColor.Cyan),
                new Block(1,0,ShapeColor.Cyan),
                new Block(2,0,ShapeColor.Cyan),
                new Block(3,0,ShapeColor.Cyan)
            };

            Blocks = blocks;
            ShapeColor = ShapeColor.Cyan;

        }

    }
}