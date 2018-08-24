using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
