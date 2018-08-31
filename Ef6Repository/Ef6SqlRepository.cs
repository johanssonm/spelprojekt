using Infrastructure.Contracts;
using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositories
{
    public class Ef6SqlRepository : IPlayerRepository
    {
        public void Save(Player player)
        {
            using (var context = new Ef6Context())
            {
                context.Players.Add(player);
                context.SaveChanges();
            }
        }

        public void Update(IPlayer player)
        {
            using (var context = new Ef6Context())
            {
                try
                {
                    var oldPlayer = context.Players.Where(p => p.Id == player.Id).SingleOrDefault();

                    oldPlayer = (Player)player;

                    context.Players.Add(oldPlayer);
                    context.SaveChanges();

                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e + " Player was not found");
                }

            }
        }

        public void Save(IPlayer player)
        {
            using (var context = new Ef6Context())
            {
                context.Players.Add(player as Player);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Ef6Context())
            {
                try
                {
                    var result = context.Players.Where(p => p.Identity.Id == id).SingleOrDefault();

                    context.Players.Remove(result);
                    context.SaveChanges();

                }

                catch (NullReferenceException e)
                {
                    throw new ArgumentException(e.Message + $" Player with {id} was not found");
                }

            }

        }

        public IPlayer FindOne(int id)
        {
            using (var context = new Ef6Context())
            {
                try
                {
                    return context.Players.Where(p => p.Id == id)
                        .Include(s => s.Scores)
                        .Select(p => new ApiQueryPlayerResult
                        {
                            Id = p.Id,
                            Name = p.Identity.Name,
                            Scores = p.Scores
                        }
                        ) as Player;

                }

                catch (NullReferenceException e)
                {
                    throw new ArgumentException(e.Message + $" Player with {id} was not found");
                }

            }
        }

        public IEnumerable<IPlayer> FindAll()
        {
            var players = new List<ApiQueryPlayerResult>();

            using (var context = new Ef6Context())
            {
                players = context.Players
                    .Include(i => i.Identity)
                    .Include(s => s.Scores)
                    .Select(p => new ApiQueryPlayerResult
                    {
                        Id = p.Id,
                        Name = p.Identity.Name,
                        Scores = p.Scores
                    }
                     ).ToList();

            }

            return players;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
