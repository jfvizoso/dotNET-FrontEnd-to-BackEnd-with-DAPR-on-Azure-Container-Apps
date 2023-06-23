using Microsoft.EntityFrameworkCore;

namespace Store
{
    public class VizoContext : DbContext
    {
        public VizoContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<VizoEntity> Vizo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VizoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
