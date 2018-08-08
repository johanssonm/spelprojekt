using System;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    class ShapeService
    {
        public enum Rotations
        {
            Default,
            Left,
            Down,
            Right
        }

        public void OnGameUpdated(object source, EventArgs e)
        {
            var message = "Shapeservice";
            MessageBox.Show(message);



        }

        public Shape FallDown(Shape shape)
        {
            shape.OffsetY += 1;

            return shape;
        }


    }
}
