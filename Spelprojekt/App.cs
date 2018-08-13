using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        private ShapeService _shapeService;

        private GameService _gameService;

        private Game _game;

        public App() : base(1000)
        {

            _game = new Game();

            _game.GameGrid = new GameGrid(10,20);

            _shapeService = new ShapeService();

            var shape = new LShape();

            _shapeService.ShapeInPlayState = shape;

            _shapeService.ShapeInPlayState.IsInPlay = true;
            

        }

        protected override void UpdateGame()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (!_shapeService.InBounds(shape, _game))
            {
                _shapeService.ShapeInPlayState.IsInPlay = false;
            }

            if (shape.IsInPlay)
            {
                _shapeService.ShapeInPlayState.GameGridYPosition++;

            }

        }

        protected override void Render(IRender render)
        {
            var grid = _game.GameGrid.GameGridArray;

            var shape = _shapeService.ShapeInPlayState;
            var shapeGridWidth = shape.ShapeGridArea.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGridArea[i, j])
                        render.Draw(i + shape.GameGridXPosition, j + shape.GameGridYPosition, shape.ShapeColor);
                }

            }

            var y = _game.GameGrid.X -1;
            var x = _game.GameGrid.Y -1;

            for (int i = 0; i <= y; i++)
            {
                for (int j = 0; j <= x; j++)
                {
                    if (grid[i, j])
                        render.Draw(i, j, ShapeColor.Cyan);
                }

            }
        }

        protected override void Rotate()
        {
            if (_shapeService.ShapeInPlayState.IsInPlay && _shapeService.ShapeInPlayState.CanBeRotated)
            {
                _shapeService.ShapeInPlayState.ShapeGridArea = _shapeService.Rotate(_shapeService.ShapeInPlayState.ShapeGridArea,(int)Math.Sqrt(_shapeService.ShapeInPlayState.ShapeGridArea.Length));

            }
        }

        protected override void Drop()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (shape.IsInPlay)
            {
                shape.GameGridYPosition =_game.GameGrid.Y - (int)Math.Sqrt(shape.ShapeGridArea.Length);
                shape.IsInPlay = false;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }

        }

        protected override void MoveLeft()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (shape.IsInPlay && _shapeService.InBounds(shape, _game))
            {
                shape.GameGridXPosition--;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }


        }

        protected override void MoveRight()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (shape.IsInPlay && _shapeService.InBounds(shape, _game))
            {
                shape.GameGridXPosition++;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }

        }
    }
}
