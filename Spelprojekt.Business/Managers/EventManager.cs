using System;
using Spelprojekt.Infrastructure;

namespace Spelprojekt.Business.Managers
{
    public class EventManager
    {
    private EventHandlerService _eventHandler => new EventHandlerService();
    private GameManager _gameManager => new GameManager();


        public void GameChangeEvents(object obj, EventHandlerService.GameEventArgs e)
        {
            _eventHandler.GameUpdated += _gameManager.OnGameUpdated;
        }
    
    

    }
}
