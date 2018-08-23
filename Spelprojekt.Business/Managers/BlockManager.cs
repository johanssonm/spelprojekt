using Spelprojekt.Entities;
using System.Collections.Generic;
using System.Linq;
using Spelprojekt.Services;

namespace Spelprojekt.Business.Managers
{
    class BlockManager
    {
        public static bool CheckForBlockYAxisCollisions(Game game)
        {

            game.ShapeInPlay.GameGridYPosition++;

            var shapepos = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);
            game.ShapeInPlay.GameGridYPosition--;

            if (yResult.Count() != 0)
            {
                return true;
            }

            return false;

        }

        public static bool CheckForBlockRightMovementCollisions(Game game)
        {

            game.ShapeInPlay.GameGridXPosition++;

            var shapepos = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);

            game.ShapeInPlay.GameGridXPosition--;

            if (yResult.Count() != 0)
            {
                return true;
            }

            return false;

        }

        public static bool CheckForBlockLeftMovementCollisions(Game game)
        {

            game.ShapeInPlay.GameGridXPosition--;

            var shapepos = ShapeManager.CurrentLocationOfShapeInPlay(game.ShapeInPlay);

            var heappos = new List<string>();

            foreach (var block in game.GameGrid.Squares)
            {
                heappos.Add(block.Coordinates);
            }

            var yResult = heappos.Intersect(shapepos);

            game.ShapeInPlay.GameGridXPosition++;

            if (yResult.Count() != 0)
            {
                return true;
            }

            return false;

        }

    }
}
