using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spelprojekt.Services
{
    public class GameService
   
    {

        private ShapeService shapeService => new ShapeService();

        public void OnGameUpdated(Shape shape, Game game)
        {

            try
            {
                if (game.InPlay)
                {
                    if (!shapeService.CheckForBlockYAxisCollisions(game.ShapeInPlay, game) &&
                        !CollisionBottomLine(game))
                    {
                        shape.IsInPlay = true;
                    }

                    if (game.InPlay && !shape.IsInPlay)
                    {
                        shapeService.AddShapeToHeap(shape, game);
                        SpawnNewShape(game);
                        game.InPlay = shapeService.CheckForBlockYAxisCollisions(shape, game);

                    }


                    game.InPlay = !GameOverController(game);


                    if (game.InPlay)
                    {
                        MoveShapeInPlay(shape, game, shapeService);

                        game.Score.Points += 10;
                    }

                    if (!game.InPlay)
                    {
                        var dataservice = new DatabaseService();

                        var message = "Game over";

                        //MessageBox.Show(message); TODO: Bryt ut till Gui

                        var player = new Player();

                        //player.Identity.Name = App.Prompt.ShowDialog("Enter your name","Enter your name");
                        player.Scores.Add(game.Score);

                        dataservice.Save(player);


                    }


                    CheckForCompleteLineAndClearIfComplete(game);
                }
            }

            catch (NullReferenceException e)
            {
                throw;
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

        public void CheckForCompleteLineAndClearIfComplete(Game game)
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

        private bool GameOverController(Game game)
        {
            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
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

        private void MoveShapeInPlay(Shape shape, Game game, ShapeService shapeService)
        {
            game.ShapeInPlay.GameGridYPosition++;

            if (shapeService.CheckForBlockYAxisCollisions(shape, game))
            {
                shape.IsInPlay = false;
            }

            if (CollisionBottomLine(game))
            {
                shape.IsInPlay = false;
            }
        }

        private static void SpawnNewShape(Game game)
        {
            var shape = game.ShapeInPlay;

            game.ShapesPlayed++;

            var log = new Filelogger();

            log.LogShape(shape);


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


        public bool CollisionBottomLine(Game game)
        {
            var shape = game.ShapeInPlay;

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

        public bool CollisionLeftSide(Game game)
        {
            var shape = game.ShapeInPlay;

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

        public bool CollisionRightSide(Game game)
        {
            var shape = game.ShapeInPlay;

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
