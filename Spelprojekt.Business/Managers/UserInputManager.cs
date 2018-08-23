using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisUI;

namespace Spelprojekt.Business.Managers
{
    public class UserInputManager
    {
        protected override void Rotate()
        {
            _ShapeManager.RotateShape(_shape, _game, _GameManager, _ShapeManager);
        }

        protected override void Drop()
        {
            _ShapeManager.DropShape(_shape, _game, _ShapeManager, _GameManager);
        }


        protected override void MoveLeft()
        {
            MoveShapeLeft(_shape, _game, _ShapeManager, _GameManager);
        }

        protected override void MoveRight()
        {
            _ShapeManager.MoveShapeRight(_shape, _game, _GameManager, _ShapeManager);
        }
    }
}
