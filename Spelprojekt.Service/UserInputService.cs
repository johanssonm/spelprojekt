using Spelprojekt.Entities;
using Spelprojekt.Infrastructure;

namespace Spelprojekt.Services
{

    public class UserInputService
    {
        private EventHandlerService _eventHandler => new EventHandlerService();

        public void Rotate(Game game)
        {
           // _shapeManager.RotateShape(game);
            _eventHandler.OnShapeRotated(game);

        }

        public void Drop(Game game)
        {
           // _shapeManager.DropShape(game);
            _eventHandler.OnShapeDropped(game);
        }


        public void MoveLeft(Game game)
        {
            // _shapeManager.MoveShapeLeft(game);
            _eventHandler.OnShapeMovedLeft(game);
        }

        public void MoveRight(Game game)
        {
           // _shapeManager.MoveShapeRight(game);
            _eventHandler.OnShapeMovedRight(game);
        }

    }
}
