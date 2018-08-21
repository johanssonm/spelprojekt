using Microsoft.EntityFrameworkCore;
using Spelprojekt.Entities;

namespace Spelprojekt.Data
{
    public class GameContext : DbContext
    {
        public GameContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = Spelprojekt; Trusted_Connection = True; ");
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }

    }
}