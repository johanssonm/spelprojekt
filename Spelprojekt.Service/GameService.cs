using Spelprojekt.Business.Managers;
using Spelprojekt.Entities;
using Spelprojekt.Infrastructure;
using TetrisUI;

namespace Spelprojekt.Service
{
    public class GameService
    {
        private GameManager _gameManager => new GameManager();
        private EventHandlerService _eventHandler => new EventHandlerService();
        private EventManager _EventManager => new EventManager();

        public Game StartNewGame()
        {
            _eventHandler.OnNewGameStarted();
            return _gameManager.StartNewGame();
        }

        public void OnGameUpdated(Game game)
        {
            _eventHandler.OnGameUpdated(game);
            _eventHandler.GameUpdated += _EventManager.GameChangeEvents;

        }

        public static void RenderGame(IRender render, Game game)
        {
            RenderManager.RenderShapes(render, game);
        }

    }
}
