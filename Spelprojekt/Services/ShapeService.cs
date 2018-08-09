using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TetrisUI;

namespace Spelprojekt.Services
{
    class ShapeService
    {
        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public bool ShapeInPlayState { get; set; }

        public Shape UpdatePositionOfShape(Shape shape, int X, int Y)
        {

            shape.OffsetX = X;
            shape.OffsetY = Y;

            return shape;

        }

        public Shape RotateShape(Shape shape)
        {

            shape.Blocks.Clear();

            if (shape is IShape)
            {
                if (shape.RotationState == Shape.Rotation.Default)
                {
                    shape.Blocks = new List<Block>
                    {
                        new Block(3,0,ShapeColor.Cyan),
                        new Block(3,1,ShapeColor.Cyan),
                        new Block(3,2,ShapeColor.Cyan),
                        new Block(3,3,ShapeColor.Cyan)
                    };

                }

                if (shape.RotationState == Shape.Rotation.Right)
                {
                    shape.Blocks = new List<Block>
                    {
                        new Block(3,0,ShapeColor.Cyan),
                        new Block(3,1,ShapeColor.Cyan),
                        new Block(3,2,ShapeColor.Cyan),
                        new Block(3,3,ShapeColor.Cyan)
                    };

                }

                if (shape.RotationState == Shape.Rotation.Down)
                {
                    shape.Blocks = new List<Block>
                    {
                        new Block(0,3,ShapeColor.Cyan),
                        new Block(1,3,ShapeColor.Cyan),
                        new Block(2,3,ShapeColor.Cyan),
                        new Block(3,3,ShapeColor.Cyan)
                    };

                }

                if (shape.RotationState == Shape.Rotation.Left)
                {
                    shape.Blocks = new List<Block>
                    {
                        new Block(0,1,ShapeColor.Cyan),
                        new Block(1,1,ShapeColor.Cyan),
                        new Block(2,1,ShapeColor.Cyan),
                        new Block(3,1,ShapeColor.Cyan)
                    };

                }

            }

            return shape;

        }

        public Shape UpdateShapeState(Shape shape, bool inplay)
        {
            shape.InPlay = inplay;

            return shape;

        }

        public void OnGameUpdated(object source, EventArgs e)
        {
            var message = "Shapeservice";
            MessageBox.Show(message);
        }
    }
}
