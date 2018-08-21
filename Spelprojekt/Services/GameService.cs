using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    public class GameService

    {
        public void OnGameUpdated(Shape shape, Game game, ShapeService shapeService, ScoreService scoreService)
        {
         

            if (game.InPlay)
            {
                if (!shapeService.CheckForBlockYAxisCollisions(shape, game) &&
                    !CollisionBottomLine(shape, game, shapeService))
                {
                    shape.IsInPlay = true;
                }

                if (game.InPlay && !shape.IsInPlay)
                {
                    shapeService.AddShapeToHeap(shape, game);
                    SpawnNewShape(shape, game, shapeService);
                    game.InPlay = shapeService.CheckForBlockYAxisCollisions(shape, game);

                }


                game.InPlay = !GameOverController(shape, game, shapeService);


                if (game.InPlay)
                {
                    MoveShapeInPlay(shape, game, shapeService);

                    game.Score.ScoreAmount += scoreService.LineMoved;
                }

                if (!game.InPlay)
                {
                    var dataservice = new DatabaseService();

                    var message = "Game over";

                    MessageBox.Show(message);

                    game.Player.Name = App.Prompt.ShowDialog("Enter your name","Testing");


                    dataservice.SaveScore(game.Score);


                }


                CheckForCompleteLineAndClearIfComplete(game, scoreService);



            }

        }

        private void MoveHeapAfterCompletedLineIsRemoved(int row, Game game)
        {
            foreach (var block in game.GameGrid.Squares)
            {
                if (block.Y < row)
                {
                    block.Y++;
                }
            }


        }

        public void CheckForCompleteLineAndClearIfComplete(Game game, ScoreService scoreService)
        {
            
            var query = game.GameGrid.Squares.GroupBy(x => x.Y)
                .Select(group => new
                {
                    Row = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Row);

            var result = query.Where(x => x.Count == 20);

            foreach (var row in result)
            {

                ClearRow(row.Row, game);

                MoveHeapAfterCompletedLineIsRemoved(row.Row, game);

            }


        }

        private void ClearRow(int row, Game game)
        {
                game.GameGrid.Squares.RemoveAll(x => x.Y == row);
        }

        private bool GameOverController(Shape shape, Game game, ShapeService shapeService)
        {
            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Coordinates);
            }

            var gameOverPos = new List<string>()
            {
                "3x1",
                "4x1",
                "5x1",
                "6x1"
            };


            var result = heappos.Intersect(gameOverPos);


            if (result.Count() != 0)
                return true;

            return false;

        }




        private void MoveShapeInPlay(Shape shape, Game game, ShapeService shapeService)
        {
            shapeService.ShapeInPlayState.GameGridYPosition++;

            if (shapeService.CheckForBlockYAxisCollisions(shape, game))
            {
                shape.IsInPlay = false;
            }

            if (CollisionBottomLine(shape, game, shapeService))
            {
                shape.IsInPlay = false;
            }
        }

        private static void SpawnNewShape(Shape shape, Game game, ShapeService shapeService)
        {
            game.ShapesPlayed++;

            var log = new Filelogger();

            log.LogShape(shape);


            try
            {
                var newShape = game.Shapes.PickRandom();

                shapeService.ShapeInPlayState = newShape;

                shapeService.ShapeInPlayState.GameGridYPosition = -1;
                shapeService.ShapeInPlayState.GameGridXPosition = 3;
                shapeService.ShapeInPlayState.IsInPlay = true;
            }

            catch (NullReferenceException e)
            {
                var message = e.Message;
                MessageBox.Show(message);
            }
        }


        public bool CollisionBottomLine(Shape shape, Game game, ShapeService shapeService)
        {
            var shapeblocks = shapeService.CurrentLocationOfShapeInPlay(shape);

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

        public bool CollisionLeftSide(Shape shape, ShapeService shapeService)
        {
            var shapeblocks = shapeService.CurrentLocationOfShapeInPlay(shape);

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

        public bool CollisionRightSide(Shape shape, ShapeService shapeService)
        {
            var shapeblocks = shapeService.CurrentLocationOfShapeInPlay(shape);

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




    }
}
