using Business.Contracts;
using Infrastructure.Entities;
using System;
using TetrisUI;

namespace Business
{
    public class ShapeManager
    {
        private GameLogicManager gameLogic = new GameLogicManager();
        public void RotateShape(IShape shape, IGame game)
        {
            RotateShape(shape, game);
        }

        public void DropShape(IShape shape, IGame game)
        {
            if (shape.IsInPlay && game.InPlay)
            {
                while (game.ShapeInPlay.IsInPlay)
                {
                    game.ShapeInPlay.GameGridYPosition++;

                    if (gameLogic.CheckForBlockYAxisCollisions(shape, game))
                    {
                        shape.IsInPlay = false;
                    }

                    if (gameLogic.CollisionBottomLine(game)) // TODO: Lägg med i update
                    {
                        shape.IsInPlay = false;
                    }

                }

                game.ShapeInPlay.IsInPlay = false;

            }
        }

        public void RenderShapes(IRender render, IGame game)
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

            }
        }

        public void MoveShapeRight(IShape shape, IGame game)
        {
            if (shape.IsInPlay && !gameLogic.CollisionRightSide(game) &&
                !gameLogic.CheckForBlockRightMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition++;
        }

        public void MoveShapeLeft(IShape shape, IGame game)
        {
            if (shape.IsInPlay && !gameLogic.CollisionLeftSide(game) &&
                !gameLogic.CheckForBlockLeftMovementCollisions(shape, game)
                && game.InPlay)

                shape.GameGridXPosition--;
        }
    }
}
