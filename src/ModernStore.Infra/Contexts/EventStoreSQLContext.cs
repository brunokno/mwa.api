using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModernStore.Domain.Core.Events;
using ModernStore.Infra.Mappings;
using ModernStore.Shared;
using System.IO;

namespace ModernStore.Infra.Contexts
{
    public class EventStoreSQLContext : DbContext
    {
        //https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/
        //add-Migration  -context ModernStoreDataContext
        //update-database -context ModernStoreDataContext

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreEventMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("CnnStr"));
        }
    }
}
