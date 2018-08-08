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
            var game = new Game();


            _shapeService = new ShapeService();

            game.Shapes = new List<Shape>
            {
                new IShape()
            };

            var block = new Block(4, 0);


            var gameService = new GameService();
            var shapeService = new ShapeService();

            GameUpdated += gameService.OnGameUpdated;
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
        }

        protected void CheckShapeForValidState(object source, EventArgs e)
        {

        }


        protected override void Render(IRender render)
        {
            var block = new Block(4,0);


            render.Draw(block.XPosition + _shapeService.ShapeInPlayX, block.YPosition + _shapeService.ShapeInPlayY, ShapeColor.Green);
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

            //  throw new NotImplementedException();
        }

        protected override void MoveLeft()
        {
            //var message = "Move left";
            //MessageBox.Show(message);
            if(_shapeService.ShapeInPlayX > -4)
            _shapeService.ShapeInPlayX -= 1;

            // throw new NotImplementedException();
        }

        protected override void MoveRight()
        {
            //var message = "Move right";
            //MessageBox.Show(message);

            if(_shapeService.ShapeInPlayX < 5)
            _shapeService.ShapeInPlayX += 1;

            // throw new NotImplementedException();
        }
    }
}
