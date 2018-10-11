﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap :IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id); //.HasName("Id");
            builder.Property(x => x.Image).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Price);
            builder.Property(x => x.QuantityOnHand);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(80);

            //builder.Ignore(x => x.Notifications);
        }
    }
}
