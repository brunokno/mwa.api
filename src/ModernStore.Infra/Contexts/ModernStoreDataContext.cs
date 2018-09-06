using Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("ModernStoreConnectionstring");
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().OwnsOne(typeof(Document), "Document");

            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new OrderItemMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
