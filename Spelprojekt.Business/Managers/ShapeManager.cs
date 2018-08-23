using System;
using Spelprojekt.Business;
using Spelprojekt.Entities;
using System.Collections.Generic;
using Spelprojekt.Business.Managers;

namespace Spelprojekt.Services
{
    public class ShapeManager
    {

        private GameManager _gameManager => new GameManager();
        
        public Shape ShapeInPlayState { get; set; }

        public void RotateShape(Game game)
        {

            if (ShapeInPlayState.IsInPlay && ShapeInPlayState.CanBeRotated &&
                !BlockManager.CheckForBlockLeftMovementCollisions(game) &&
                !BlockManager.CheckForBlockRightMovementCollisions(game) &&
                !BlockManager.CheckForBlockYAxisCollisions(game))
            {
                ShapeInPlayState.ShapeGrid =
                    RotateArray(ShapeInPlayState.ShapeGrid, game.ShapeInPlay.ShapeGrid.GetLength(0));
            }
        }

        public void DropShape(Game game)
        {
            try
            {
                if (game.ShapeInPlay.IsInPlay && game.InPlay)
                {
                    while (ShapeInPlayState.IsInPlay)
                    {
                        ShapeInPlayState.GameGridYPosition++;

                        if (BlockManager.CheckForBlockYAxisCollisions(game))
                        {
                            game.ShapeInPlay.IsInPlay = false;
                        }

                        if (_gameManager.CollisionBottomLine(game))
                        {
                            game.ShapeInPlay.IsInPlay = false;
                        }

                    }

                    AddShapeToHeap(game);
                    ShapeInPlayState.IsInPlay = false;
                }
            }

            catch (NullReferenceException e)
            {

            }


        }
        

        public void MoveShapeRight(Game game)
        {
            try
            {
                if (game.ShapeInPlay.IsInPlay && game.InPlay &&
                    !_gameManager.CollisionRightSide(game) &&
                    !BlockManager.CheckForBlockRightMovementCollisions(game))

                    game.ShapeInPlay.GameGridXPosition++;
            }
            catch (NullReferenceException e)
            {

            }

        }

        public void MoveShapeLeft(Game game)
        {
            try
            {
                if (game.ShapeInPlay.IsInPlay && !_gameManager.CollisionLeftSide(game) &&
                    !BlockManager.CheckForBlockLeftMovementCollisions(game)
                    && game.InPlay)

                    ShapeInPlayState.GameGridXPosition--;
            }
            catch (NullReferenceException e)
            {

            }

        }


        public static Shape RotateShape(Shape shape)
        {
            int shapeGridLength = shape.ShapeGrid.GetLength(0);

            bool[,] result = new bool[shapeGridLength, shapeGridLength];

            for (int i = 0; i < shapeGridLength; ++i)
            {
                for (int j = 0; j < shapeGridLength; ++j)
                {
                    result[i, j] = shape.ShapeGrid[j, shapeGridLength - i - 1];
                }
            }
            shape.ShapeGrid = result;

            return shape;
        }

        public bool[,] RotateArray(bool[,] grid, int n)
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

        public static List<string> CurrentLocationOfShapeInPlay(Shape shape)
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

        public void AddShapeToHeap(Game game)
        {

            var shapeGridWidth = game.ShapeInPlay.ShapeGrid.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (game.ShapeInPlay.ShapeGrid[i, j])
                        game.GameGrid.Squares.Add(new Block(i + game.ShapeInPlay.GameGridXPosition,j + game.ShapeInPlay.GameGridYPosition, game.ShapeInPlay.ShapeColor));


                }

            }



        }
    

    }
}

