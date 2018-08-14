using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

            _game.GameGrid = new GameGrid(10, 20);

            _shapeService = new ShapeService();


            if(_game.InPlay)
            {
                Random rnd = new Random();

                int r = rnd.Next((_game.Shapes.Count));

                _shapeService.ShapeInPlayState = _game.Shapes[r];

                _shapeService.ShapeInPlayState.CurrentWidth = _shapeService.CheckCurrentWidthOfShape(_shapeService.ShapeInPlayState);
                _shapeService.ShapeInPlayState.IsInPlay = true;

            }

        }

        protected override void UpdateGame()
        {
            var shape = _shapeService.ShapeInPlayState;
            CollisionCheckWDictionary(shape, _game);

            //if (CollisionCheck(shape, _game))
            //{
            //    throw new Exception("Collision occured");
            //}



            if (shape.IsInPlay)
            {
                _shapeService.ShapeInPlayState.GameGridYPosition++;

            }

        }

        private bool CollisionCheckWDictionary(Shape shape, Game game)
        {
            var shapeCoordinates = new Dictionary<string, bool>();

            try
            {
                for (int i = 0; i < game.GameGrid.GameGridArray.GetLength(0); ++i)
                {
                    for (int j = 0; j < game.GameGrid.GameGridArray.GetLength(1); ++j)
                    {
                        if (game.GameGrid.GameGridArray[i, j])
                        {
                            shapeCoordinates.Add($"row{i}col{j}", true);
                        }
                    }
                }

                for (int i = 0; i < shape.ShapeGridArea.GetLength(0); ++i)
                {
                    for (int j = 0; j < shape.ShapeGridArea.GetLength(0); ++j)
                    {
                        if (shape.ShapeGridArea[i, j])
                        {
                            shapeCoordinates.Add($"row{i}col{j}", true);
                        }
                    }
                }

                return false;

            }
            catch (Exception e)
            {
                return true;
                throw;
            }



        }


        private bool CollisionCheck(Shape shape, Game game)
        {
            var result = 0;

            for (int i = 0; i < shape.ShapeGridArea.GetLength(0); ++i)
            {
                for (int j = 0; j < shape.ShapeGridArea.GetLength(0); ++j)
                {
                    if (shape.ShapeGridArea[i, j])
                    {
                        if (game.GameGrid.GameGridArray[i + shape.GameGridYPosition, j + shape.GameGridXPosition])
                        {
                            result++;
                        }
                    }
                }
            }

            if (result != 0)
            {
                return true;
            }

            return false;


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

            var y = _game.GameGrid.X - 1;
            var x = _game.GameGrid.Y - 1;

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
            var shape = _shapeService.ShapeInPlayState;

            if (_shapeService.ShapeInPlayState.IsInPlay && _shapeService.ShapeInPlayState.CanBeRotated)
            {
                _shapeService.ShapeInPlayState.ShapeGridArea = _shapeService.Rotate(_shapeService.ShapeInPlayState.ShapeGridArea, shape.ShapeGridArea.GetLength(0));


            }
        }

        protected override void Drop()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (shape.IsInPlay && _shapeService.InBoundsBottom(shape, _game))
            {
                shape.GameGridYPosition = _game.GameGrid.Y - shape.ShapeGridArea.GetLength(1);

                _shapeService.AddShapeToHeap(shape, _game);

                shape.IsInPlay = false;

                _shapeService.ShapeInPlayState = _game.Shapes.FirstOrDefault();
                _shapeService.ShapeInPlayState.GameGridYPosition = 0;
                _shapeService.ShapeInPlayState.GameGridXPosition = 4;
                _shapeService.ShapeInPlayState.IsInPlay = true;

            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }

        }

        protected override void MoveLeft()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (_shapeService.InBoundsLeft(shape, _game))
            {
                shape.GameGridXPosition--;
            }




        }

        protected override void MoveRight()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (_shapeService.InBoundsRight(shape, _game))
            {
                shape.GameGridXPosition++;
            }


        }
    }
}
