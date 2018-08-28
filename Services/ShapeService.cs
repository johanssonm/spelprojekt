using Business;
using Business.Contracts;
using Infrastructure.Entities;
using TetrisUI;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
       private ShapeManager shapeManager => new ShapeManager();
        public void RotateShape(IShape shape, IGame game)
        {
            shapeManager.RotateShape(shape, game);
        }

        public void DropShape(IShape shape, IGame game)
        {
            shapeManager.DropShape(shape, game);
        }

        public void RenderShapes(IRender render, IGame game)
        {
            shapeManager.RenderShapes(render, game);
        }

        public void MoveShapeRight(IShape shape, IGame game)
        {
            shapeManager.MoveShapeRight(shape, game);
        }

        public void MoveShapeLeft(IShape shape, IGame game)
        {
            shapeManager.MoveShapeLeft(shape,game);
        }

    }
}

