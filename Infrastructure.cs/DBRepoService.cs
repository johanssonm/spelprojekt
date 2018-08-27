using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Spelprojekt.Data;
using Spelprojekt.Entities;

namespace Infrastructure.cs
{
    public class DBRepoService
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
                context.Add(player);
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
