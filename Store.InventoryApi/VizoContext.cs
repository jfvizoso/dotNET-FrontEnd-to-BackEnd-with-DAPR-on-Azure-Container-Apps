using Microsoft.EntityFrameworkCore;

namespace Store.InventoryApi
{
    public class VizoContext : DbContext
    {
        public VizoContext(DbContextOptions options)
            : base(options)
        {
            
            //var conn = (System.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();
            //var credential = new Azure.Identity.DefaultAzureCredential();
            //var token = credential.GetToken(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/.default" }));
            //conn.AccessToken = token.Token;
        }

        public DbSet<VizoEntity> Vizo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VizoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
