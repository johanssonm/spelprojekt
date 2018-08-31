using Spelprojekt.Entities;
using System.Data.Entity;

namespace Spelprojekt.Data
{
    public class Ef6Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Identity> Identity { get; set; }

        public Ef6Context()
        {
            Database.Connection.ConnectionString =
                "Server = (localdb)\\mssqllocaldb; Database = SpelprojektEf6; Trusted_Connection = True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>()
                .HasRequired(a => a.Player)
                .WithMany()
                .HasForeignKey(a => a.PlayerId)
                .WillCascadeOnDelete(true);
        }

    }
}