using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    public class GameService

    {
        public void OnGameUpdated(object source, EventArgs e)
        {
            //var message = "Gameservice";
            //MessageBox.Show(message);

        }

        public void Update(Shape shape, Game game, ShapeService shapeService)
        {
            if (game.ShapesPlayed < game.Shapes.Count() && game.InPlay)
            {
                if (!shapeService.CheckForBlockYAxisCollisions(shape, game) &&
                    !CollisionBottomLine(shape, game, shapeService))
                {
                    shape.IsInPlay = true;
                }

                if (game.InPlay && !shape.IsInPlay)
                {
                    game.ShapesPlayed++;

                    shapeService.AddShapeToHeap(shape, game);

                    shapeService.ShapeInPlayState = game.Shapes.FirstOrDefault();
                    shapeService.ShapeInPlayState.GameGridYPosition = -1;
                    shapeService.ShapeInPlayState.GameGridXPosition = 4;

                    try
                    {
                        var newShape = game.Shapes.FirstOrDefault(x => x.Id == game.ShapesPlayed);

                        shapeService.ShapeInPlayState = newShape;

                        shapeService.ShapeInPlayState.IsInPlay = true;
                    }

                    catch (NullReferenceException e)
                    {
                        var message = e.Message;
                        MessageBox.Show(message);
                    }
                }

                if (game.InPlay)
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
