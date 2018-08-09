using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        private ShapeService _shapeService;

        private GameService _gameService;

        private Game _game;

        public delegate void GameUpdatedEventHandler(object source, EventArgs e);

        public event GameUpdatedEventHandler GameUpdated;

        protected virtual void OnGameUpdated()
        {

            if (GameUpdated != null)
            {
                GameUpdated(this, EventArgs.Empty);
            }



        }

        public App() : base(1000)
        {
            _game = new Game();
            _shapeService = new ShapeService();

            var shape = new IShape();


            _shapeService.ShapeInPlayState = shape;
            _shapeService.ShapeInPlayState.InPlay = true;

            GameUpdated += MoveDown;

        }

        protected override void UpdateGame()
        {

            OnGameUpdated();

        }

        protected void MoveDown(object source, EventArgs e)
        {
            if (_shapeService.ShapeInPlayState.InPlay)
            {
                _shapeService.ShapeInPlayState.PositionY++;
            }

        }

        protected override void Render(IRender render)
        {
            var shape = _shapeService.ShapeInPlayState;

            foreach (var block in shape.Blocks)
            {
                render.Draw(block.XPosition + shape.PositionX,block.YPosition + shape.PositionY ,block.ShapeColor);
            }
      
        }

        protected override void Rotate()
        {
            RotateShape(_shapeService.ShapeInPlayState);
        }

        protected Shape RotateShape(Shape shape)
        {
            int x = (int)Math.Sqrt(shape.Width);
            int y = (int)Math.Sqrt(shape.Height);

           
            return shape;
        }



        protected override void Drop()
        {

            _shapeService.ShapeInPlayState.PositionY = 20 - _shapeService.ShapeInPlayState.Height;
            _shapeService.ShapeInPlayState.InPlay = false;

        }

        protected override void MoveLeft()
        {
            if (_shapeService.ShapeInPlayState.PositionX > 0 && _shapeService.ShapeInPlayState.InPlay)
            {
                _shapeService.ShapeInPlayState.PositionX--;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }
            
        }

        protected override void MoveRight()
        {
            var shape = _shapeService.ShapeInPlayState;

            if (shape.PositionX < 10 - shape.Width && shape.InPlay)
            {
                _shapeService.ShapeInPlayState.PositionX++;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }

        }
    }
}
