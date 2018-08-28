using Microsoft.EntityFrameworkCore;
using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.cs.Contracts;

namespace Repositories
{
    public class SqlRepository : IPlayerRepository
    {
        public void Save(Player player)
        {
            using (var context = new GameContext())
            {
                context.Add(player);
                context.SaveChanges();
            }
        }

        public void Update(Player player)
        {
            using (var context = new GameContext())
            {
                try
                {
                    var oldPlayer = context.Players.Where(p => p.Identity.Name.ToLower() == player.Identity.Name.ToLower()).SingleOrDefault();

                    oldPlayer.Scores.Add(player.Scores.FirstOrDefault());

                    context.Update(player);
                    context.SaveChanges();

                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e + " Player was not found");
                }

            }
        }

        public void Delete(Player player)
        {
            using (var context = new GameContext())
            {
                context.Remove(player);
                context.SaveChanges();
            }

        }

        public Player FindOne(int id)
        {
            var player = new Player();

            using (var context = new GameContext())
            {
               player = context.Players.Where(x => x.Id == id).FirstOrDefault();
               player.Identity = context.Identity.Where(x => x.PlayerId == id).FirstOrDefault();
               player.Scores = context.Scores.Where(x => x.PlayerId == id).ToList();

            }

            return player;


        }

        public IEnumerable<Player> FindAll()
        {
            var players = new List<Player>();

            using (var context = new GameContext())
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

            return players;

        }


    }
}
