using System;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        public App() : base(1000)
        {

        }

        protected override void UpdateGame()
        {
            //throw new NotImplementedException();
        }

        protected override void Render(IRender render)
        {
            var i = 15;

            render.Draw(3, 3 + i, ShapeColor.Cyan);
            render.Draw(3, 4 + i, ShapeColor.Cyan);
            render.Draw(3, 5 + i, ShapeColor.Cyan);
            render.Draw(3, 6 + i, ShapeColor.Cyan);



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
