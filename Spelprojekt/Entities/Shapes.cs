using System.Collections.Generic;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt
{


    public abstract class Shape
    {
        public int ID { get; set; }
        public List<Block> Blocks { get; set; }
        public bool InPlay { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
    }

    public class TestShape : Shape
    {
        public TestShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0,ShapeColor.Green)
            };

            Blocks = blocks;
        }

    }

    public class IShape : Shape
    {
        public IShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0,ShapeColor.Cyan),
                new Block(2,0,ShapeColor.Cyan),
                new Block(3,0,ShapeColor.Cyan),
                new Block(4,0,ShapeColor.Cyan)
            };

            Blocks = blocks;
        }

    }

    public class JShape : Shape
    {


    }

    public class LShape : Shape
    {

    }

    public class OShape : Shape
    {

    }

    public class SShape : Shape
    {

    }

    public class TShape : Shape
    {

    }

    public class ZShape : Shape
    {

    }
}