using System.Collections.Generic;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt
{


    public abstract class Shape
    {
        public int ID { get; set; }
        public ShapeColor ShapeColor { get; set; }
        public List<Block> Blocks { get; set; }
        public bool InPlay { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public Rotation RotationState { get; set; }

        public enum Rotation
        {
            Default,
            Left,
            Down,
            Right
        }
    }

<<<<<<< HEAD
    public class TestShape : Shape
    {
        public TestShape()
        {
            var blocks = new List<Block>()
            {
                new Block(0 + OffsetX,0 + OffsetY,ShapeColor.Green)
            };

            Blocks = blocks;
            RotationState = Rotation.Default;
        }

    }

=======
>>>>>>> parent of b6a97b5... Fungerande primitiv med blocks
    public class IShape : Shape
    {
        public IShape()
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

    public class JShape : Shape
    {
        public JShape()
        {
            var blocks = new List<Block>()
            {
                new Block(0,0,ShapeColor.Blue),
                new Block(0,1,ShapeColor.Blue),
                new Block(1,1,ShapeColor.Blue),
                new Block(2,1,ShapeColor.Blue)
            };

            Blocks = blocks;
        }


    }

    public class LShape : Shape
    {
        public LShape()
        {
            var blocks = new List<Block>()
            {
                new Block(0,1,ShapeColor.Orange),
                new Block(1,1,ShapeColor.Orange),
                new Block(2,1,ShapeColor.Orange),
                new Block(2,0,ShapeColor.Orange)
            };

            Blocks = blocks;
        }

    }

    public class OShape : Shape
    {

        public OShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0,ShapeColor.Yellow),
                new Block(2,0,ShapeColor.Yellow),
                new Block(1,1,ShapeColor.Yellow),
                new Block(2,1,ShapeColor.Yellow)
            };

            Blocks = blocks;

        }

    }

    public class SShape : Shape
    {
        public SShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0,ShapeColor.Green),
                new Block(2,0,ShapeColor.Green),
                new Block(0,1,ShapeColor.Green),
                new Block(1,1,ShapeColor.Green)
            };

            Blocks = blocks;
        }

    }

    public class TShape : Shape
    {
        public TShape()
        {
            var blocks = new List<Block>()
            {
                new Block(1,0,ShapeColor.Purple),
                new Block(0,1,ShapeColor.Purple),
                new Block(1,1,ShapeColor.Purple),
                new Block(2,1,ShapeColor.Purple)
            };

            Blocks = blocks;
        }

    }

    public class ZShape : Shape
    {
        public ZShape()
        {
            var blocks = new List<Block>()
            {
                new Block(0,0,ShapeColor.Red),
                new Block(1,0,ShapeColor.Red),
                new Block(1,1,ShapeColor.Red),
                new Block(2,1,ShapeColor.Red)
            };

            Blocks = blocks;
        }

    }
}