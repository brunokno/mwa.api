using Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;
using ModernStore.Shared.Entities;

namespace ModernStore.Infra.Mappings
{
    public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public override void Map(EntityTypeBuilder<T> builder)
        {
            //builder.HasKey(c => c.Id).HasName("Id");
            //builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            //builder.Property(c => c.Active).HasColumnName("Active").IsRequired();
            //builder.Property(c => c.RegistrationDate).HasColumnName("RegistrationDate").IsRequired();
            //builder.Property(c => c.DateModified).HasColumnName("DateModified");
        }
    }
}
