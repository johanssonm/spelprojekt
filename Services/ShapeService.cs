using System;
using Spelprojekt.Entities;
using System.Collections.Generic;
using System.Linq;
using TetrisUI;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
       private GameService gameService => new GameService();
        public void RotateShape(Shape shape, Game game)
        {
            gameService.CheckForCompleteLineAndClearIfComplete(game);

            if (game.ShapeInPlay.IsInPlay && game.ShapeInPlay.CanBeRotated &&
                !CheckForBlockLeftMovementCollisions(shape, game) &&
                !CheckForBlockRightMovementCollisions(shape, game) &&
                !CheckForBlockYAxisCollisions(shape, game))
            {
                game.ShapeInPlay.ShapeGrid =
                    Rotate(game.ShapeInPlay.ShapeGrid, shape.ShapeGrid.GetLength(0));
            }
        }

        public void DropShape(Shape shape, Game game)
        {
            if (shape.IsInPlay && game.InPlay)
            {
                while (game.ShapeInPlay.IsInPlay)
                {
                    game.ShapeInPlay.GameGridYPosition++;

                    if (CheckForBlockYAxisCollisions(shape, game))
                    {
                        shape.IsInPlay = false;
                    }

                    if (gameService.CollisionBottomLine(game)) // TODO: Lägg med i update
                    {
                        shape.IsInPlay = false;
                    }

                }

                //AddShapeToHeap(shape, game);
                game.ShapeInPlay.IsInPlay = false;

                
            }
        }

        public void RenderShapes(IRender render, Game game)
        {
            var shape = game.ShapeInPlay;
            try
            {
                var shapeGridWidth = shape.ShapeGrid.GetLength(0);

                for (int i = 0; i < shapeGridWidth; i++)
                {
                    for (int j = 0; j < shapeGridWidth; j++)
                    {
                        if (shape.ShapeGrid[i, j])
                            render.Draw(i + shape.GameGridXPosition, j + shape.GameGridYPosition, shape.ShapeColor);
                    }
                }

                foreach (var block in game.GameGrid.Blocks)
                {
                    render.Draw(block.X, block.Y, block.ShapeColor);
                }
            }

            catch (NullReferenceException)
            {
                game.InPlay = false;
                game.ShapeInPlay = new TestShape();
                game.ShapeInPlay.IsInPlay = false;
            }
        }

        public void MoveShapeRight(Shape shape, Game game)
        {
            if (shape.IsInPlay && !gameService.CollisionRightSide(game) &&
                !CheckForBlockRightMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition++;
        }

        public void MoveShapeLeft(Shape shape, Game game)
        {
            if (shape.IsInPlay && !gameService.CollisionLeftSide(game) &&
                !CheckForBlockLeftMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition--;
        }



        private bool[,] Rotate(bool[,] grid, int n)
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

        public List<string> CurrentLocationOfShapeInPlay(Shape shape)
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

        public void AddShapeToHeap(Shape shape, Game game)
        {

            var shapeGridWidth = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGrid[i, j])
                        game.GameGrid.Blocks.Add(new Block(i + shape.GameGridXPosition,j + shape.GameGridYPosition, shape.ShapeColor));


                }

            }



        }

        public bool CheckForBlockYAxisCollisions(Shape shape, Game game)
        {

            shape.GameGridYPosition++;

            var shapepos = CurrentLocationOfShapeInPlay(shape);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Blocks)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);
            shape.GameGridYPosition--;

            if (yResult.Count() != 0)
            {
                return true;
            }

            return false;
       
        }

        public bool CheckForBlockRightMovementCollisions(Shape shape, Game game)
        {

            shape.GameGridXPosition++;

            var shapepos = CurrentLocationOfShapeInPlay(shape);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Blocks)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);

            shape.GameGridXPosition--;

            if (yResult.Count() != 0)
            {
                return true;
            }

            return false;

        }

        public bool CheckForBlockLeftMovementCollisions(Shape shape, Game game)
        {

            shape.GameGridXPosition--;

            var shapepos = CurrentLocationOfShapeInPlay(shape);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Blocks)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);

            shape.GameGridXPosition++;

            if (yResult.Count() != 0) 
            {
                return true;
            }

            return false;

        }


    }
}

