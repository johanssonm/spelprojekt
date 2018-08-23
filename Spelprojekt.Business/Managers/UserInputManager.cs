using Spelprojekt.Entities;
using Spelprojekt.Services;

namespace Spelprojekt.Business.Managers
{

    public class UserInputManager
    {
        private ShapeManager _shapeManager => new ShapeManager();

        public void Rotate(Game game)
        {
            _shapeManager.RotateShape(game);
        }

        public void Drop(Game game)
        {
            _shapeManager.DropShape(game);
        }


        public void MoveLeft(Game game)
        {
            _shapeManager.MoveShapeLeft(game);
        }

        public void MoveRight(Game game)
        {
            _shapeManager.MoveShapeRight(game);
        }
    }
}
