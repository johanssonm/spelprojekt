using Spelprojekt.Entities;
using System.Collections.Generic;
using Infrastructure.Contracts;

namespace Infrastructure.cs.Contracts
{
    public interface IRepository
    {
        void Save<T>(T obj);

        void Update<T>(T obj);

        void Delete<T>(T obj);

        object FindOne(int objId);

        IEnumerable<T> FindAll<T>();
    }
}
