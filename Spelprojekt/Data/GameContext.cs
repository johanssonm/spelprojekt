using Microsoft.EntityFrameworkCore;
using Spelprojekt.Entities;

namespace Spelprojekt.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        //public DbSet<PlayerScore> PlayerScores { get; set; }

        public GameContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(
                    "Server = (localdb)\\mssqllocaldb; Database = Spelprojekt; Trusted_Connection = True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         // modelBuilder.Entity<PlayerScore>().HasKey(sb => new { sb.PlayerId, sb.ScoreId });
        }

    }
}