using Spelprojekt.Entities;
using System.Collections.Generic;
using Infrastructure.Contracts;

namespace Infrastructure.Contracts
{
    public interface IPlayerRepository
    {
        void Save(IPlayer player);

        void Update(IPlayer player);

        void Delete(int id);

        IPlayer FindOne(int objId);

        IEnumerable<IPlayer> FindAll();
    }
}
