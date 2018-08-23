using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using TetrisUI;

namespace Spelprojekt.Business.Managers
{
    public class RenderManager
    {
        public static void RenderShapes(IRender render, Game game)
        {
            try
            {
                var shapeGridWidth = game.ShapeInPlay.ShapeGrid.GetLength(0);

                for (int i = 0; i < shapeGridWidth; i++)
                {
                    for (int j = 0; j < shapeGridWidth; j++)
                    {
                        if (game.ShapeInPlay.ShapeGrid[i, j])
                            render.Draw(i + game.ShapeInPlay.GameGridXPosition, j + game.ShapeInPlay.GameGridYPosition, game.ShapeInPlay.ShapeColor);
                    }
                }

                foreach (var block in game.GameGrid.Squares)
                {
                    render.Draw(block.X, block.Y, block.ShapeColor);
                }
            }

            catch (NullReferenceException e)
            {
                // TODO : Kanske kasta ett exception
            }
        }

    }
}
