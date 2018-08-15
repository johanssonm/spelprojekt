using System;
using Spelprojekt.Entities;
using System.Collections.Generic;
using System.Linq;
using TetrisUI;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
        public Shape ShapeInPlayState { get; set; }

        public void RotateShape()
        {
            var shape = ShapeInPlayState;

            if (ShapeInPlayState.IsInPlay && ShapeInPlayState.CanBeRotated)
            {
                ShapeInPlayState.ShapeGrid =
                    Rotate(ShapeInPlayState.ShapeGrid, shape.ShapeGrid.GetLength(0));
            }
        }

        public void DropShape(Shape shape, Game game, ShapeService _shapeService, GameService _gameService)
        {
            if (shape.IsInPlay && game.InPlay)
            {
                while (ShapeInPlayState.IsInPlay)
                {
                    ShapeInPlayState.GameGridYPosition++;

                    if (CheckForBlockYAxisCollisions(shape, game))
                    {
                        shape.IsInPlay = false;
                    }

                    if (_gameService.CollisionBottomLine(shape, game, _shapeService))
                    {
                        shape.IsInPlay = false;
                    }

                }

                AddShapeToHeap(shape, game);
                ShapeInPlayState.IsInPlay = false;

            }
        }

        public void RenderShapes(IRender render, Game game, Shape shape, ShapeService shapeService)
        {
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

                foreach (var block in game.GameGrid.Squares)
                {
                    var tmpblock = block.Id.Split('x');

                    render.Draw(Int32.Parse(tmpblock[0]), Int32.Parse(tmpblock[1]), block.ShapeColor);
                }
            }

            catch (NullReferenceException)
            {
                game.InPlay = false;
                shapeService.ShapeInPlayState = new TestShape();
                shapeService.ShapeInPlayState.IsInPlay = false;
            }
        }

        public void MoveShapeRight(Shape shape, Game game, GameService gameService, ShapeService shapeService)
        {
            if (shape.IsInPlay && !gameService.CollisionRightSide(shape, shapeService) &&
                !shapeService.CheckForBlockRightMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition++;
        }

        public void MoveShapeLeft(Shape shape, Game game, ShapeService shapeService,GameService gameService)
        {
            if (shape.IsInPlay && !gameService.CollisionLeftSide(shape, shapeService) &&
                !shapeService.CheckForBlockLeftMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition--;
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
                        game.GameGrid.Squares.Add(new Block($"{i + shape.GameGridXPosition}x{j + shape.GameGridYPosition}", shape.ShapeColor));
                }

            }


        }

        public bool CheckForBlockYAxisCollisions(Shape shape, Game game)
        {

            shape.GameGridYPosition++;

            var shapepos = CurrentLocationOfShapeInPlay(shape);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Id);
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

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Id);
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

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Id);
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

