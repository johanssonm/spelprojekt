using System.Diagnostics;
using System.Linq;
using Spelprojekt.Entities;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public Shape ShapeInPlayState { get; set; }

        public bool InBoundsLeft(Shape shape, Game game)
        {
            int currentLeft = FindLeftLocation(shape);



            if (0 < shape.GameGridXPosition)
                return true;

                return false;

        }

        public bool InBoundsRight(Shape shape, Game game)
        {
            int currentRight = FindRightLocation(shape);

            if (shape.GameGridXPosition + currentRight < 10)
                return true;

            return false;

        }

        public bool InBoundsBottom(Shape shape, Game game)
        {
            int currentBottom = FindRightLocation(shape);

            if (shape.GameGridYPosition + (shape.ShapeGridArea.GetLength(0)) == 20)
                return true;

            return false;

        }

        private static int FindLeftLocation(Shape shape)
        {

            int counter = 0;

            for (int i = 0; i < shape.ShapeGridArea.GetLength(0); ++i)
            {


                if (!shape.ShapeGridArea[i, 0])
                {
                    counter++;
                }



            }

            if (counter == 0)
            {
               return 1;
            }

            return 0;


        }

        private static int FindRightLocation(Shape shape)
        {

            int counter = 0;

            for (int i = 0; i < shape.ShapeGridArea.GetLength(0); ++i)
            {


                if (!shape.ShapeGridArea[i, shape.ShapeGridArea.GetLength(0) - 1])
                {
                    counter++;
                }



            }

            if (counter != 0)
            {
                return shape.ShapeGridArea.GetLength(0) - 1;
            }

            return shape.ShapeGridArea.GetLength(0);


        }

        public bool[,] Rotate(bool[,] grid, int n)
        {
            bool[,] result = new bool[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    result[i, j] = grid[j, n - i - 1];
                }
            }

            return result;
        }

        public int CheckCurrentWidthOfShape(Shape shape)
        {

            var maxWidth = new System.Collections.Generic.List<int>();

            for (int i = 0; i < shape.ShapeGridArea.GetLength(0); ++i)
            {
                int counter = 0;

                for (int j = 0; j < shape.ShapeGridArea.GetLength(0); ++j)
                {


                    if (shape.ShapeGridArea[i, j])
                    {
                        counter++;
                    }


                }

                maxWidth.Add(counter);
            }

            return maxWidth.Max();
        }

        public void AddShapeToHeap(Shape shape, Game game)
        {

            var shapeGridWidth = shape.ShapeGridArea.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGridArea[i, j])
                        game.GameGrid.GameGridArray[i + shape.GameGridXPosition, j + shape.GameGridYPosition] = true;
                }

            }


        }
    }
}
