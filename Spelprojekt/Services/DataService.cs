using Spelprojekt.Data;
using Spelprojekt.Entities;

namespace Spelprojekt.Services
{
    public class DatabaseService
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
