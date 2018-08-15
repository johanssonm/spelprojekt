using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    public class GameService

    {
        public void OnGameUpdated(Shape shape, Game game, ShapeService shapeService)
        {

            if (game.InPlay) // game.ShapesPlayed < game.Shapes.Count()  TODO: Kan behövas för debug
            {
                if (!shapeService.CheckForBlockYAxisCollisions(shape, game) &&
                    !CollisionBottomLine(shape, game, shapeService))
                {
                    shape.IsInPlay = true;
                }

                if (game.InPlay && !shape.IsInPlay)
                {
                    SpawnNewShape(shape, game, shapeService);
                }

                game.InPlay = !GameOverController(shape, game, shapeService);

                if (game.InPlay)
                {
                    MoveShapeInPlay(shape, game, shapeService);
                }

                if (!game.InPlay)
                {
                    var message = "Game over";
                    MessageBox.Show(message);
                }



            }

        }

        private bool GameOverController(Shape shape, Game game, ShapeService shapeService)
        {
            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Id);
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

            shapeService.AddShapeToHeap(shape, game);

            // shapeService.ShapeInPlayState = game.Shapes.FirstOrDefault();


            try
            {
                var newShape = game.Shapes.PickRandom();

                shapeService.ShapeInPlayState = newShape;

                shapeService.ShapeInPlayState.GameGridYPosition = -1;
                shapeService.ShapeInPlayState.GameGridXPosition = 4;
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

            if (bottomMargin == game.GameGrid.Y - 1)
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
