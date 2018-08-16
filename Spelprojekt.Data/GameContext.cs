using System.Data.Entity;
using Spelprojekt.Entities;

namespace Spelprojekt.Data
{
    public class GameContext : DbContext
    {
        public GameContext() : base()
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}