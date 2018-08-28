using Spelprojekt.Entities;
using System.Collections.Generic;

namespace Infrastructure.cs.Contracts
{
    public interface IPlayerRepository
    {
        void Save(Player player);

        void Update(Player player);

        void Delete(Player player);

        Player FindOne(int playerId);

        IEnumerable<Player> FindAll();
    }
}
