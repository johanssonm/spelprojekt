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
            var service = new ShapeService();


            var rotatedShape = new IShape();

            var controlArray = new bool[4, 4];

            controlArray[2, 0] = true;
            controlArray[2, 1] = true;
            controlArray[2, 2] = true;
            controlArray[2, 3] = true;

            rotatedShape.ShapeGridArea = service.Rotate(rotatedShape.ShapeGridArea, 4);

            rotatedShape.ShapeGridArea.Should().BeEquivalentTo(controlArray);

        }

        [TestMethod]
        public void ValidateMethodForRotatingTShapeTwice()
        {
            var service = new ShapeService();


            var rotatedShape = new TShape();

            var controlArray = new bool[3, 3];

            controlArray[1, 0] = true;
            controlArray[1, 1] = true;
            controlArray[1, 2] = true;
            controlArray[2, 1] = true;

            rotatedShape.ShapeGridArea = service.Rotate(rotatedShape.ShapeGridArea, 3);
            rotatedShape.ShapeGridArea = service.Rotate(rotatedShape.ShapeGridArea, 3);

            rotatedShape.ShapeGridArea.Should().BeEquivalentTo(controlArray);

        }


    }
}
