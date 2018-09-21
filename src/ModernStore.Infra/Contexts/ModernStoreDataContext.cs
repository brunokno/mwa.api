using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Infra.Mappings;
using ModernStore.Shared;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext:DbContext
    {
        //https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/
        //add-migration initial
        //update database

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().OwnsOne(typeof(Document), "Document");
            builder.Entity<Customer>().OwnsOne(typeof(Email), "Email");
            builder.Entity<Customer>().OwnsOne(typeof(Name),"Name");

            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new OrderItemMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Runtime.ConnectionString);
        }
    }
}
