using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TetrisUI;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
        private readonly IShapeRotator _shaperotator;

        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public Shape ShapeInPlayState { get; set; }

        public Shape UpdatePositionOfShape(Shape shape, int X, int Y)
        {

            shape.PositionX = X;
            shape.PositionX = Y;

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
