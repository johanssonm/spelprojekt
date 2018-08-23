using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Spelprojekt.Infrastructure;

namespace Spelprojekt.Business.Managers
{
    public class GameManager

    {
        private ShapeManager _shapeManager { get; set; }
        private ScoreManager _scoreManager { get; set; }

        public Game StartNewGame()
        {
            var game = new Game();

            game.GameGrid = new GameGrid(10, 20);

            _shapeManager = new ShapeManager();

            _scoreManager = new ScoreManager();

            game.Player = new Player();

            game.Player.Identity = new Identity();

            game.Score = new Score();

            game.ShapeInPlay = game.Shapes.First();

            game.ShapeInPlay.IsInPlay = true;

            var events = new EventHandlerService();

            events.GameUpdated += OnGameUpdated;

            return game;
        }

        

        public void OnGameUpdated(object source,EventHandlerService.GameEventArgs e)
        {

            try
            {
                if (e.Game.InPlay)
                {
                    if (!BlockManager.CheckForBlockYAxisCollisions(e.Game) &&
                        !CollisionBottomLine(e.Game))
                    {
                        e.Game.ShapeInPlay.IsInPlay = true;
                    }

                    if (e.Game.InPlay && !e.Game.ShapeInPlay.IsInPlay)
                    {
                        _shapeManager.AddShapeToHeap(e.Game);
                        SpawnNewShape(e.Game);
                        e.Game.InPlay = BlockManager.CheckForBlockYAxisCollisions(e.Game);

                    }

                    e.Game.InPlay = !GameOverController(e.Game);
                    
                    if (e.Game.InPlay)
                    {
                        MoveShapeInPlay(e.Game);

                        e.Game.Score.Points += 10; // TODO: Flytta till ScoreManager
                    }

                    if (!e.Game.InPlay)
                    {
                        // var dataservice = new DatabaseService(); // TODO : Gör till event

                        var message = "Game over";

                        // MessageBox.Show(message); // TODO:Flytta till gui

                        var player = new Player();

                        //player.Identity.Name = App.Prompt.ShowDialog("Enter your name","Enter your name");
                        // player.Scores.Add(game.Score);

                        //  dataservice.Save(player);


                    }


                    CheckForCompleteLineAndClearIfComplete(e.Game);



                }

            }
            catch (NullReferenceException ex)
            {

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

        private void MoveShapeInPlay(Game game)
        {
            game.ShapeInPlay.GameGridYPosition++;

            if (BlockManager.CheckForBlockYAxisCollisions(game))
            {
                game.ShapeInPlay.IsInPlay = false;
            }

            if (CollisionBottomLine(game))
            {
                game.ShapeInPlay.IsInPlay = false;
            }
        }

        private static void SpawnNewShape(Game game)
        {
            game.ShapesPlayed++;

            try
            {
                var newShape = game.Shapes.PickRandom();

                game.ShapeInPlay = newShape;

                game.ShapeInPlay.GameGridYPosition = -1;
                game.ShapeInPlay.GameGridXPosition = 3;
                game.ShapeInPlay.IsInPlay = true;
            }

            catch (NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }


        public bool CollisionBottomLine(Game game)
        {
            var shapeblocks = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

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
            var shapeblocks = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

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
            var shapeblocks = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

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
