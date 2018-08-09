using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Spelprojekt.Entities;
using Spelprojekt.Services;
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
            _shapeService.ShapeInPlayState = true;

            _game.Blocks = new List<Block>
            {
                new Block(5, 4, ShapeColor.Blue),
                new Block(5, 5, ShapeColor.Red),
                new Block(5, 6, ShapeColor.Green)
            };

            GameUpdated += MoveDown;



        }

        protected override void UpdateGame()
        {


            OnGameUpdated();

        }

        protected void MoveDown(object source, EventArgs e)
        {
            if(_shapeService.ShapeInPlayY < 19)
            _shapeService.ShapeInPlayY += 1;

            if (_shapeService.ShapeInPlayY == 19)
            {
                _shapeService.ShapeInPlayState = false;
            }
        }

        protected override void Render(IRender render)
        {
<<<<<<< HEAD
            
            var game = _game.Blocks;

            var shape = new IShape();
            
            //foreach (var b in shape.Blocks)
            //{
            //    render.Draw(b.XPosition, b.YPosition, b.ShapeColor);
            //}
=======
            var usedBlocks = _game.Blocks;

            var block = new Block(4,0, ShapeColor.Purple);

            foreach (var b in usedBlocks)
            {
                render.Draw(b.XPosition, b.YPosition, b.ShapeColor);
            }
>>>>>>> parent of b6a97b5... Fungerande primitiv med blocks
           
           render.Draw(shape.XPosition + _shapeService.ShapeInPlayX, shape.YPosition + _shapeService.ShapeInPlayY, block.ShapeColor);
           
        }

        protected override void Rotate()
        {


        }

        protected override void Drop()
        {

            _shapeService.ShapeInPlayY = 19;
            _shapeService.ShapeInPlayState = false;

        }

        protected override void MoveLeft()
        {
            if (_shapeService.ShapeInPlayX > -4 && _shapeService.ShapeInPlayState == true)
            {
                _shapeService.ShapeInPlayX -= 1;
            }

                        else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }
            
        }

        protected override void MoveRight()
        {

            if (_shapeService.ShapeInPlayX < 5 && _shapeService.ShapeInPlayState == true)
            {
                _shapeService.ShapeInPlayX += 1;
            }

            else
            {
                _shapeService.ShapeInPlayX = _shapeService.ShapeInPlayX;
            }

        }
    }
}
