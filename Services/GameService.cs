using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Business.Contracts;
using Infrastructure.Entities;

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
