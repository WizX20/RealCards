using Microsoft.EntityFrameworkCore;
using RealCardsApp.Data.Entities;

namespace RealCardsApp.Data
{
    /// <summary>
    /// Database Context
    /// - https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=visual-studio
    /// - https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
    /// </summary>
    public class RealCardsContext : DbContext
    {
        public DbSet<GameInstance> GameInstances { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>()
            //    .Property(e => e.Id)
            //    .IsRequired();

            //modelBuilder.Entity<Deck>()
            //    .Property(e => e.Id)
            //    .IsRequired();

            //modelBuilder.Entity<Card>()
            //    .Property(e => e.Id)
            //    .IsRequired();

            //modelBuilder.Entity<CardType>()
            //    .Property(e => e.Id)
            //    .IsRequired();

            //modelBuilder.Entity<Player>()
            //    .Property(e => e.Id)
            //    .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=RealCards.sqlite");
    }
}