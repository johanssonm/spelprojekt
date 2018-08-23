using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using TetrisUI;

namespace Spelprojekt.Business.Managers
{
    class RenderManager
    {
        public void RenderShapes(IRender render, Game game, Shape shape, ShapeManager ShapeManager)
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
                    render.Draw(block.X, block.Y, block.ShapeColor);
                }
            }

            catch (NullReferenceException)
            {
                game.InPlay = false;
                ShapeManager.ShapeInPlayState = new TestShape();
                ShapeManager.ShapeInPlayState.IsInPlay = false;
            }
        }

    }
}
