using System;
using Spelprojekt.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public Shape ShapeInPlayState { get; set; }

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

        public List<string> UpdateBlockLocation(Shape shape)
        {
            var coordinates = new List<string>();

            int n = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if(shape.ShapeGrid[i,j])
                    coordinates.Add($"{i + shape.GameGridXPosition}x{j + shape.GameGridYPosition}");
                }
            }

            return coordinates;
        }

        public List<string> CurrentShapeDimensions(Shape shape)
        {
            var coordinates = new List<string>();

            int n = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (shape.ShapeGrid[i, j])
                        coordinates.Add($"{i}x{j}");
                }
            }

            return coordinates;
        }

        public int FindBottomOfShape(Shape shape)
        {
            var shapeblocks = CurrentShapeDimensions(shape);

            var yList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');

                yList.Add(Int32.Parse(tmpstring[1]));

            }

            int shapeBottom = yList.Max();

            return shapeBottom;
        }

        public void AddShapeToHeap(Shape shape, Game game)
        {

            var shapeGridWidth = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGrid[i, j])
                        game.GameGrid.GameGridArray[i + shape.GameGridXPosition, j + shape.GameGridYPosition] = true;
                }

            }


        }
    }
}
