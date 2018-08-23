using Spelprojekt.Entities;

namespace Spelprojekt.Services
{

    public class UserInputService
    {
        private EventHandlerService _eventHandler => new EventHandlerService();
        private ShapeManager _shapeManager => new ShapeManager();

        public void Rotate(Game game)
        {
            _shapeManager.RotateShape(game);
            _eventHandler.OnShapeRotated();

        }

        public void Drop(Game game)
        {
            _shapeManager.DropShape(game);
            _eventHandler.OnShapeDropped();
        }


        public void MoveLeft(Game game)
        {
            _shapeManager.MoveShapeLeft(game);
            _eventHandler.OnShapeMovedLeft();
        }

        public void MoveRight(Game game)
        {
           _shapeManager.MoveShapeRight(game);
            _eventHandler.OnShapeMovedRight();
        }

    }
}
