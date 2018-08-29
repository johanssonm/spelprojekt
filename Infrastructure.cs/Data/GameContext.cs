using Infrastructure.Contracts;
using Infrastructure.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Spelprojekt.Entities;

namespace Spelprojekt.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Identity> Identity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb;" +
                                        "Database = Spelprojekt; Trusted_Connection = True; ");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }


    }
}