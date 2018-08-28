using System;
using System.Collections.Generic;
using System.Linq;
using Business.Contracts;
using Infrastructure.Entities;
using Spelprojekt;

namespace Business
{
    public class GameLogicManager
    {
        public void RotateShape(IShape shape, IGame game)
        {
            CheckForCompleteLineAndClearIfComplete(game);

            if (game.ShapeInPlay.IsInPlay && game.ShapeInPlay.CanBeRotated &&
                !CheckForBlockLeftMovementCollisions(shape, game) &&
                !CheckForBlockRightMovementCollisions(shape, game) &&
                !CheckForBlockYAxisCollisions(shape, game))
            {
                game.ShapeInPlay.ShapeGrid =
                    Rotate(game.ShapeInPlay.ShapeGrid, shape.ShapeGrid.GetLength(0));
            }
        }

        public bool GameOverController(IGame game)
        {
            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Blocks)
            {
                heappos.Add(block.Coordinates);
            }

            var gameOverPos = new List<string>();

            gameOverPos.Add("3x1");
            gameOverPos.Add("4x1");
            gameOverPos.Add("5x1");
            gameOverPos.Add("6x1");

            var result = heappos.Intersect(gameOverPos);


            if (result.Count() != 0)
                return true;

            return false;

        }

        private void MoveShapeInPlay(IShape shape, IGame game)
        {
            game.ShapeInPlay.GameGridYPosition++;

            if (CheckForBlockYAxisCollisions(shape, game))
            {
                shape.IsInPlay = false;
            }

            if (CollisionBottomLine(game))
            {
                shape.IsInPlay = false;
            }
        }

        private static void SpawnNewShape(IGame game)
        {
            game.ShapesPlayed++;

            try
            {

                game.ShapeInPlay = game.Shapes.PickRandom();

                game.ShapeInPlay.GameGridYPosition = -1;
                game.ShapeInPlay.GameGridXPosition = 4;
                game.ShapeInPlay.IsInPlay = true;
            }

            catch (NullReferenceException e)
            {
                // var message = e.Message; TODO: Flytta ut till Gui
                //  MessageBox.Show(message);
            }
        }

        public bool CheckForBlockYAxisCollisions(IShape shape, IGame game)
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

        public bool CheckForBlockRightMovementCollisions(IShape shape, IGame game)
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

        public bool CheckForBlockLeftMovementCollisions(IShape shape, IGame game)
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

        public bool CollisionBottomLine(IGame game)
        {
            var shape = game.ShapeInPlay;

            var shapeblocks = CurrentLocationOfShapeInPlay(shape);

            var yList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');

                yList.Add(Int32.Parse(tmpstring[1]));

            }

            int bottomMargin = yList.Max();

            if (bottomMargin == game.GameGrid.Height - 1)
                return true;

            return false;

        }

        public bool CollisionLeftSide(IGame game)
        {
            var shape = game.ShapeInPlay;

            var shapeblocks = CurrentLocationOfShapeInPlay(shape);

            var xList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');

                xList.Add(Int32.Parse(tmpstring[0]));

            }

            int leftMargin = xList.Min();

            if (leftMargin == 0)
                return true;

            return false;

        }

        public bool CollisionRightSide(IGame game)
        {
            var shape = game.ShapeInPlay;

            var shapeblocks = CurrentLocationOfShapeInPlay(shape);

            var xList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');
                xList.Add(Int32.Parse(tmpstring[0]));

            }

            int rightMargin = xList.Max();

            if (rightMargin == 9)
                return true;

            return false;

        }

        private void MoveHeapAfterCompletedLineIsRemoved(int row, IGame game)
        {
            foreach (var block in game.GameGrid.Blocks)
            {
                if (block.Y < row)
                {
                    block.Y++;
                }
            }
        }

        public void CheckForCompleteLineAndClearIfComplete(IGame game)
        {

            var query = game.GameGrid.Blocks.GroupBy(x => x.Y)
                .Select(group => new
                {
                    Row = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Row);

            var result = query.Where(x => x.Count == 10);

            foreach (var row in result)
            {
                ClearRow(row.Row, game);
                MoveHeapAfterCompletedLineIsRemoved(row.Row, game);
            }


        }

        private void ClearRow(int row, IGame game)
        {
            game.GameGrid.Blocks.RemoveAll(x => x.Y == row);
        }

        public List<string> CurrentLocationOfShapeInPlay(IShape shape)
        {
            var coordinates = new List<string>();

            int n = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (shape.ShapeGrid[i, j])
                        coordinates.Add($"{i + shape.GameGridXPosition}x{j + shape.GameGridYPosition}");
                }
            }

            return coordinates;
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

        public void UpdateGame(IShape shape, IGame game)
        {
            if (game.InPlay)
            {
                if (!CheckForBlockYAxisCollisions(game.ShapeInPlay, game) &&
                    !CollisionBottomLine(game))
                {
                    shape.IsInPlay = true;
                }

                if (CheckForBlockYAxisCollisions(shape, game) ||
                    CollisionBottomLine(game))
                {
                    shape.IsInPlay = false;
                }

                if (game.InPlay && !shape.IsInPlay)
                {
                    AddShapeToHeap(shape, game);
                    SpawnNewShape(game);
                    game.InPlay = CheckForBlockYAxisCollisions(shape, game);
                    CheckForCompleteLineAndClearIfComplete(game);
                }

                game.InPlay = !GameOverController(game);


                if (game.InPlay)
                {
                    MoveShapeInPlay(shape, game);

                    game.Score.Points += 10;
                }

                if (!game.InPlay)
                {
                    game.GameOver = true;
                }
            }
        }

        public void AddShapeToHeap(IShape shape, IGame game)
        {

            var shapeGridWidth = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGrid[i, j])
                        game.GameGrid.Blocks.Add(new Block(i + shape.GameGridXPosition, j + shape.GameGridYPosition, shape.ShapeColor));


                }

            }



        }

        public IShape MakeRandomShape()
        {
            IShape shape = null;


            return shape;
        }
    }
}
