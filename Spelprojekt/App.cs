using Spelprojekt.Entities;
using Spelprojekt.Services;
using System.Linq;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        private ShapeService _shapeService;

        private GameService _gameService;

        private Game _game;
        private Shape _shape => _shapeService.ShapeInPlayState;

        public App() : base(1000)
        {

            _game = new Game();

            _game.GameGrid = new GameGrid(10, 20);

            _shapeService = new ShapeService();
            _gameService = new GameService();


            if(_game.InPlay)
            {

                _shapeService.ShapeInPlayState = _game.Shapes.First();

                _shapeService.ShapeInPlayState.IsInPlay = true;

            }

        }

        protected override void UpdateGame()
        {
            _gameService.OnGameUpdated(_shape, _game, _shapeService);
        }

        protected override void Render(IRender render)
        {
            _shapeService.RenderShapes(render, _game, _shape, _shapeService);
        }

        protected override void Rotate()
        {
           _shapeService.RotateShape(_shape, _game, _gameService, _shapeService);
        }

        protected override void Drop()
        {
            _shapeService.DropShape(_shape,_game,_shapeService,_gameService);

        }


        protected override void MoveLeft()
        {
            _shapeService.MoveShapeLeft(_shape, _game, _shapeService, _gameService);
        }

        protected override void MoveRight()
        {
            _shapeService.MoveShapeRight(_shape, _game, _gameService, _shapeService);
        }

    }
}
