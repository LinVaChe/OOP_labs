using Microsoft.EntityFrameworkCore;
using lab3.Models;
namespace lab3
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Studio> Studios => Set<Studio>();  
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Ending> Endings => Set<Ending>();

        public DbSet<GameAndEnding> GameAndEndings => Set<GameAndEnding>();
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
        public DbSet<lab3.Models.Studio> Studio { get; set; } = default!;
        public DbSet<lab3.Models.Ending> Ending { get; set; } = default!;
        public DbSet<lab3.Models.GameAndEnding> GameAndEnding { get; set; } = default!;
    }
}
