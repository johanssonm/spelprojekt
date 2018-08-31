using Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class EfCoreSqlRepository : IPlayerRepository
    {
        public void Save(Player player)
        {
            using (var context = new EfCoreContext())
            {
                context.Add(player);
                context.SaveChanges();
            }
        }

        public void Update(IPlayer player)
        {
            using (var context = new EfCoreContext())
            {
                try
                {
                    var oldPlayer = context.Players.Where(p => p.Id == player.Id).SingleOrDefault();

                    oldPlayer = (Player)player;

                    context.Update(oldPlayer);
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
            using (var context = new EfCoreContext())
            {
                context.Add(player);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new EfCoreContext())
            {
                try
                {
                    var result = context.Players.Where(p => p.Identity.Id == id).SingleOrDefault();

                    context.Remove(result);
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
            using (var context = new EfCoreContext())
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
                        ) as IPlayer;

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

            using (var context = new EfCoreContext())
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


    }
}
