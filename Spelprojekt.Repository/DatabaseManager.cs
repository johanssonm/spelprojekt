using Spelprojekt.Entities;
using Spelprojekt.Repository;

namespace Spelprojekt.Services
{
    public class DataManager
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
