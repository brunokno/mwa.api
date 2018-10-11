using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Core.Events;

namespace ModernStore.Infra.Mappings
{
    public class StoreEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(x => x.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(x => x.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
