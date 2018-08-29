using Microsoft.EntityFrameworkCore;
using Spelprojekt.Data;
using Spelprojekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.cs.Contracts;
using Infrastructure.Contracts;
using Infrastructure.Entities.Contracts;

namespace Repositories
{
    public class SqlRepository : IRepository
    {
        public void Save(Player player)
        {
            using (var context = new GameContext())
            {
                context.Add((Player)player);
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

        object IRepository.FindOne(int objId)
        {
            return FindOne(objId);
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public Player FindOne(int id)
        {
            var player = new Player();
            IIdentity identity = new Identity();
            IScore scores = new Score();

            using (var context = new GameContext())
            {
               player = context.Players.Where(x => x.Id == id).FirstOrDefault();
             //  player.Identity = context.Identity.Where(x => x.PlayerId == id).FirstOrDefault();
             //  player.Scores = context.Scores.Where(x => x.PlayerId == id).ToList();

            }

            return player;


        }

        public IEnumerable<IPlayer> FindAll()
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

            return new List<IPlayer>(players);

        }


    }
}
