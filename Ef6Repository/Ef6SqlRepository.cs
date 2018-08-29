using Infrastructure.cs.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Infrastructure.Contracts;
using Spelprojekt.Data;
using Spelprojekt.Entities;

namespace Repositories
{
    public class Ef6SqlRepository : IRepository
    {
        public void Save<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public object FindOne(int objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>()
        {
            var players = new List<Player>();

            using (var context = new Ef6Context())
            {
                players = context.Players
                    .Include(i => i.Identity)
                    .Include(s => s.Scores)
                    .Select(p => new Player
                        {
                            Id = p.Id,
                            Identity = p.Identity,
                            Scores = p.Scores
                        }
                    ).ToList();

            }

            return (IEnumerable<T>)players;

        }

        public List<PlayerQuery> FindAll()
        {
            var players = new List<PlayerQuery>();

            using (var context = new Ef6Context())
            {
                players = context.Players
                    .Include(i => i.Identity)
                    .Include(s => s.Scores)
                    .Select(p => new PlayerQuery
                        {
                            Id = p.Id,
                            Name = p.Identity.Name,
                            Scores = p.Scores
                        }
                    ).ToList();

            }


            return players;

        }
    }

    public class PlayerQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Score> Scores { get; set; }
    }
}
