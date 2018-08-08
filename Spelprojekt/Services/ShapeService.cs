using System;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    class ShapeService
    {
        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public int ShapeInPlayState { get; set; }
        public int ShapeInPlayType { get; set; }


        public enum Rotations
        {
            Default,
            Left,
            Down,
            Right
        }

        public Shape UpdatePositionOfShape(Shape shape, int X, int Y)
        {

            shape.OffsetX = X;
            shape.OffsetY = Y;

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


        public int MoveDown(int y)
        {
            return y += 1;
        }


    }
}
