using Metro.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Metro.Data
{
    public class MetroDbContext : DbContext
    {
        public MetroDbContext(DbContextOptions<MetroDbContext> options)
            : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<StationConnection> StationConnections { get; set; }
        public DbSet<PricingRule> PricingRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all IEntityTypeConfiguration<T> classes automatically
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetroDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}