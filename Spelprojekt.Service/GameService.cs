using System;
using Spelprojekt.Business.Managers;
using Spelprojekt.Entities;
using Spelprojekt.Infrastructure;
using Spelprojekt.Services;
using TetrisUI;

namespace Spelprojekt.Service
{
    public class GameService
    {
        private GameManager _gameManager => new GameManager();
        private EventHandlerService _eventHandler => new EventHandlerService();

        public Game StartNewGame()
        {
            _eventHandler.OnNewGameStarted();
            return _gameManager.StartNewGame();
        }

        public void OnGameUpdated(Game game)
        {
            _gameManager.OnGameUpdated(game);
            _eventHandler.OnGameUpdated();

        }

        public static void RenderGame(IRender render, Game game)
        {
            RenderManager.RenderShapes(render, game);
        }

    }
}
