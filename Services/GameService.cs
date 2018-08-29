using Business;
using Spelprojekt.Entities;
using System;
using Infrastructure.Contracts;

namespace Spelprojekt.Services
{
    public class GameService
   
    {
        private GameLogicManager gameLogic = new GameLogicManager();

        public void OnGameUpdated(IShape shape, Game game)
        {
            try
            {
                gameLogic.UpdateGame(shape, game);
            }

            catch (NullReferenceException e)
            {
                throw;
            }

        }

     
    }
}
