using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap: IEntityTypeConfiguration<OrderItem>  
    {
        //public OrderItemMap()
        //{
        //    ToTable("OrderItem");
        //    HasKey(x => x.Id);
        //    Property(x => x.Price).HasColumnType("money");
        //    Property(x => x.Quantity);
        //    HasRequired(x => x.Product);
        //}

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(x => x.Id);//.HasName("Id");
            builder.Property(x => x.Price);//.HasColumnType("money");
            builder.Property(x => x.Quantity);
            builder.HasOne(x => x.Product);

            builder.Ignore(x => x.Notifications);
        }
    }
}
