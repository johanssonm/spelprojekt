using System;
using Spelprojekt.Infrastructure;

namespace Spelprojekt.Business.Managers
{
    class EventManager
    {
    private EventHandlerService _eventHandler => new EventHandlerService();
    private GameManager _gameManager => new GameManager();


        private void GameChangeEvents()
        {
            _eventHandler.GameUpdated += _gameManager.OnGameUpdated();
        }
    
    

    }
}
