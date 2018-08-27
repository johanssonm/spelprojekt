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
