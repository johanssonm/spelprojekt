using Infrastructure.cs;
using Spelprojekt.Data;
using Spelprojekt.Entities;

namespace Spelprojekt.Services
{
    public class DatabaseService
    {
        public void Save(Player player)
        {
            var dbrepo = new DBRepoService();

            dbrepo.Save(player);
        }
    }
}
