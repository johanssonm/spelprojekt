//using System.Collections.Generic;
//using TetrisUI;

//namespace Spelprojekt
//{
//    public class TestShape : Shape, IRotatable
//    {

//    }
//        public TestShape() : base()
//        {

//            RotationState = Rotation.Default;
//        }

//        public Shape Rotate(Shape shape)
//        {
//            shape.Blocks.Clear();

//            var blocks = new List<Block>()
//            {
//                new Block(0,0,ShapeColor.Green),
//                new Block(1,0,ShapeColor.Green),
//                new Block(0,1,ShapeColor.Green),
//                new Block(1,1,ShapeColor.Blue)
//            };

//            shape.Blocks = blocks;
//            shape.RotationState = Rotation.Right;

//            return shape;

//        }
//    }
//}