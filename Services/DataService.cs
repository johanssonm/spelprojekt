using Infrastructure.cs;
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

        public void Update(Player player)
        {
            var dbrepo = new DBRepoService();

            dbrepo.Save(player);
        }

        public void FindOne(int id)
        {
            var dbrepo = new DBRepoService();

            dbrepo.FindOne(id);
        }

        public void FindAll(Player Player)
        {
            var dbrepo = new DBRepoService();

            dbrepo.FindAll();

        }
    }


}
