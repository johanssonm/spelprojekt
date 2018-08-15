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

        private Game _game;

        private Shape _shape => _shapeService.ShapeInPlayState;

        public App() : base(1000)
        {

            _game = new Game();

            _game.GameGrid = new GameGrid(10, 20);

            _shapeService = new ShapeService();


            if(_game.InPlay)
            {
                Random rnd = new Random();

                int r = rnd.Next((_game.Shapes.Count));

                _shapeService.ShapeInPlayState = _game.Shapes.First();

                _shapeService.ShapeInPlayState.IsInPlay = true;

            }

        }

        protected override void UpdateGame()
        {

            if (_game.ShapesPlayed < _game.Shapes.Count())
            {

                _shape.IsInPlay = !_shapeService.CheckForBlockCollisions(_shape, _game);

                if (_game.InPlay && !_shape.IsInPlay)
                {
                    _game.ShapesPlayed++;

                    _shapeService.AddShapeToHeap(_shape, _game);

                    _shapeService.ShapeInPlayState = _game.Shapes.FirstOrDefault();
                    _shapeService.ShapeInPlayState.GameGridYPosition = -1;
                    _shapeService.ShapeInPlayState.GameGridXPosition = 4;

                    try
                    {
                        var newShape = _game.Shapes.FirstOrDefault(x => x.Id == _game.ShapesPlayed);


                        _shapeService.ShapeInPlayState = newShape;

                        _shapeService.ShapeInPlayState.IsInPlay = true;

                    }

                    catch (NullReferenceException e)
                    {

                    }


                }




                if (_shape.IsInPlay && !CollisionBottomLine(_shape))
                    _shapeService.ShapeInPlayState.GameGridYPosition++;

                if (CollisionBottomLine(_shape))
                    _shapeService.ShapeInPlayState.IsInPlay = false;

            }

            if (_game.ShapesPlayed < _game.Shapes.Count())
            {

            }



        }

        private bool CollisionBottomLine(Shape shape)
        {
            var shapeblocks = _shapeService.CurrentLocationOfShapeInPlay(shape);

            var yList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');

                yList.Add(Int32.Parse(tmpstring[1]));

            }

            int bottomMargin = yList.Max();

            if (bottomMargin == 19)
                return true;

            return false;

        }

        private bool CollisionLeftSide(Shape shape)
        {
            var shapeblocks = _shapeService.CurrentLocationOfShapeInPlay(shape);

            var xList = new List<int>();

            foreach (var block in shapeblocks)
            {
                var tmpstring = block.Split('x');

                xList.Add(Int32.Parse(tmpstring[0]));

            }

            int leftMargin = xList.Min();

            if(leftMargin == 0)
                return true;

            return false;

        }

        private bool CollisionRightSide(Shape shape)
        {
            var shapeblocks = _shapeService.CurrentLocationOfShapeInPlay(shape);

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

        protected override void Render(IRender render)
        {
            var grid = _game.GameGrid.GameGridArray;

            var shape = _shapeService.ShapeInPlayState;
            var shapeGridWidth = shape.ShapeGrid.GetLength(0);

            for (int i = 0; i < shapeGridWidth; i++)
            {
                for (int j = 0; j < shapeGridWidth; j++)
                {
                    if (shape.ShapeGrid[i, j])
                        render.Draw(i + shape.GameGridXPosition, j + shape.GameGridYPosition, shape.ShapeColor);
                }

            }

            foreach (var block in _game.GameGrid.Squares)
            {
               var tmpblock = block.Id.Split('x');
                 
                render.Draw(Int32.Parse(tmpblock[0]),Int32.Parse(tmpblock[1]),block.ShapeColor);


            }
        }

        protected override void Rotate()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (_shapeService.ShapeInPlayState.IsInPlay && _shapeService.ShapeInPlayState.CanBeRotated)
            {
                _shapeService.ShapeInPlayState.ShapeGrid = _shapeService.Rotate(_shapeService.ShapeInPlayState.ShapeGrid, shape.ShapeGrid.GetLength(0));

            }
        }

        protected override void Drop()
        {

            if (_shape.IsInPlay)
            {
                while (_shapeService.ShapeInPlayState.IsInPlay)
                {
                        _shapeService.ShapeInPlayState.GameGridYPosition++;

                    if (_shapeService.CheckForBlockCollisions(_shape,_game))
                    {
                        _shape.IsInPlay = false;
                    }

                    if (CollisionBottomLine(_shape))
                    {
                        _shape.IsInPlay = false;
                    }

                }

                _shapeService.AddShapeToHeap(_shape, _game);
                _shapeService.ShapeInPlayState.IsInPlay = false;

            }

        }


        protected override void MoveLeft()
        {

            if (_shape.IsInPlay && !CollisionLeftSide(_shape))
                _shape.GameGridXPosition--;

        }

        protected override void MoveRight()
        {
            if (_shape.IsInPlay && !CollisionRightSide(_shape))
                _shape.GameGridXPosition++;

        }
    }
}
