using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace ModernStore.Infra.Mappings
{
    public class UserMap :IEntityTypeConfiguration<User>
    {
        //public UserMap()
        //{
        //    ToTable("User");
        //    HasKey(x => x.Id);
        //    Property(x => x.Username).IsRequired().HasMaxLength(20);
        //    Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
        //    Property(x => x.Active);
        //}

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id); //.HasName("Id");
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(32);//.IsFixedLength();
            builder.Property(x => x.Active);

            builder.Ignore(x => x.Notifications);
        }
    }
}
