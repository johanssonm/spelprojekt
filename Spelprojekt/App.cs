using System;
using System.Collections.Generic;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
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
            


        }

        protected override void UpdateGame()
        {

            OnGameUpdated();

            // throw new NotImplementedException();
        }


        protected override void Render(IRender render)
        {
            int offsetX = 0;
            int offsetY = 0;


            var block = new Block(4,0);

            render.Draw(block.XPosition + offsetX, block.YPosition + offsetY, ShapeColor.Green);
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
            throw new NotImplementedException();
        }

        protected override void Drop()
        {
            throw new NotImplementedException();
        }

        protected override void MoveLeft()
        {
            throw new NotImplementedException();
        }

        protected override void MoveRight()
        {
            throw new NotImplementedException();
        }
    }
}
