using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Spelprojekt;
using Spelprojekt.Services;

namespace SpelprojektTester
{
    [TestClass]
    public class RotationTests
    {


        [TestMethod]
        public void ValidateMethodForRotatingIShape()
        {
            var service = new ShapeManager();


            var rotatedShape = new IShape();

            var controlArray = new bool[4, 4];

            controlArray[2, 0] = true;
            controlArray[2, 1] = true;
            controlArray[2, 2] = true;
            controlArray[2, 3] = true;

            rotatedShape.ShapeGrid = service.Rotate(rotatedShape.ShapeGrid, 4);

            rotatedShape.ShapeGrid.Should().BeEquivalentTo(controlArray);

        }

        [TestMethod]
        public void ValidateMethodForRotatingIShapeFourTimes()
        {
            var service = new ShapeManager();


            var rotatedShape = new IShape();

            var controlShape = new IShape();

            rotatedShape.ShapeGrid = service.Rotate(rotatedShape.ShapeGrid, rotatedShape.ShapeGrid.GetLength(0));
            rotatedShape.ShapeGrid = service.Rotate(rotatedShape.ShapeGrid, rotatedShape.ShapeGrid.GetLength(0));
            rotatedShape.ShapeGrid = service.Rotate(rotatedShape.ShapeGrid, rotatedShape.ShapeGrid.GetLength(0));
            rotatedShape.ShapeGrid = service.Rotate(rotatedShape.ShapeGrid, rotatedShape.ShapeGrid.GetLength(0));

            rotatedShape.ShapeGrid.Should().BeEquivalentTo(controlShape.ShapeGrid);

        }


    }
}
