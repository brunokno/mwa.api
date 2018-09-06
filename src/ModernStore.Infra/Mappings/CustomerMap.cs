using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder.ToTable("Customer");
            builder.HasKey(x => x.Id); //.HasName("Id");
            builder.Property(x => x.BirthDate);
            builder.Property(x => x.Document.Number).IsRequired().HasMaxLength(11); // .IsFixedLength();
            builder.Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            builder.HasOne(x => x.User);
        }

    }
}
