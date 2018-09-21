using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id); //.HasName("Id");
            builder.Property(x => x.BirthDate);
            //builder.Property(x => x.Document.Number).IsRequired().HasMaxLength(11); // .IsFixedLength();
            //builder.Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            //builder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            //builder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);

            builder.OwnsOne(c => c.Document)
                .Property(p => p.Number).HasColumnName("Number").IsRequired().HasMaxLength(11); ;
            builder.OwnsOne(c => c.Document)
                .Ignore(p => p.Notifications);
            builder.OwnsOne(x => x.Email)
                .Property(p => p.Address).HasColumnName("Address").IsRequired().HasMaxLength(160);
            builder.OwnsOne(x => x.Email)
                .Ignore(p => p.Notifications);
            builder.OwnsOne(x => x.Name)
                .Property(p => p.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(60);
            builder.OwnsOne(x => x.Name)
                .Ignore(p => p.Notifications);
            builder.OwnsOne(x => x.Name)
                .Property(p => p.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(60);

            builder.Ignore(x => x.Notifications);

            builder.HasOne(x => x.User);

        }

    }
}
