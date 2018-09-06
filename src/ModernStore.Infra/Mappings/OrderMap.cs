using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        //public OrderMap()
        //{
        //    ToTable("Order");
        //    HasKey(x => x.Id);
        //    Property(x => x.CreateDate);
        //    Property(x => x.DeliveryFee).HasColumnType("money");
        //    Property(x => x.Discount).HasColumnType("money");
        //    Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
        //    Property(x => x.Status);

        //    HasMany(x => x.Items);
        //    HasRequired(x => x.Customer);
        //}

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.ToTable("Order");
            builder.HasKey(x => x.Id);//.HasName("Id");
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.DeliveryFee);// .HasColumnType("money");
            builder.Property(x => x.Discount);//.HasColumnType("money");
            builder.Property(x => x.Number).IsRequired().HasMaxLength(8);//.IsFixedLength();
            builder.Property(x => x.Status);

            builder.HasMany(x => x.Items);
            builder.HasOne(x => x.Customer);

        }
    }
}
