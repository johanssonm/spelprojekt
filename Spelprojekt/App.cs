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

            // throw new NotImplementedException();
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

        protected void CheckShapeForValidState(object source, EventArgs e)
        {

        }


        protected override void Render(IRender render)
        {
            var usedBlocks = _game.Blocks;

            var block = new Block(4,0, ShapeColor.Purple);

            foreach (var b in usedBlocks)
            {
                render.Draw(b.XPosition, b.YPosition, b.ShapeColor);
            }
           
            render.Draw(block.XPosition + _shapeService.ShapeInPlayX, block.YPosition + _shapeService.ShapeInPlayY, block.ShapeColor);
           
            
            //var i = 0;

            //render.Draw(0, 1 + i, ShapeColor.Cyan);
            //render.Draw(1, 2 + i, ShapeColor.Cyan);
            //render.Draw(2, 3 + i, ShapeColor.Cyan);
            //render.Draw(3, 4 + i, ShapeColor.Cyan);


            //render.Draw(3, 4 + i, ShapeColor.Yellow);

            //throw new NotImplementedException();
        }

        protected override void Rotate()
        {

            var message = "Rotate";
            MessageBox.Show(message);

            //  throw new NotImplementedException();
        }

        protected override void Drop()
        {
            //var message = "Drop";
            //MessageBox.Show(message);

            _shapeService.ShapeInPlayY = 19;
            _shapeService.ShapeInPlayState = false;

            //  throw new NotImplementedException();
        }

        protected override void MoveLeft()
        {
            //var message = "Move left";
            //MessageBox.Show(message);
            if (_shapeService.ShapeInPlayX > -4 && _shapeService.ShapeInPlayState == true)
            {
                _shapeService.ShapeInPlayX -= 1;
            }

            // throw new NotImplementedException();
        }

        protected override void MoveRight()
        {
            //var message = "Move right";
            //MessageBox.Show(message);
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
