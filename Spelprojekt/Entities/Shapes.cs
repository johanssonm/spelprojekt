using System.Collections.Generic;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt
{


    public abstract class Shapes
    {
        public ShapeColor ShapeColor { get; set; }
        public List<Block> Blocks { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
    }

    public class IShape : Shapes
    {
        public IShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0),
                new Block(2,0),
                new Block(3,0),
                new Block(4,0)
            };

            Blocks = blocks;
            ShapeColor = ShapeColor.Cyan;

        }

    }

    public class JShape : Shapes
    {


    }

    public class LShape : Shapes
    {

    }

    public class OShape : Shapes
    {

    }

    public class SShape : Shapes
    {

    }

    public class TShape : Shapes
    {

    }

    public class ZShape : Shapes
    {

    }
}