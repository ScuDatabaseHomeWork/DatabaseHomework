using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Mapping
{
    public class RollerMap:IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.RolAdi).HasMaxLength(50).IsRequired();

            builder.HasMany(I => I.Personeller)
                .WithOne(I => I.Rol)
                .HasForeignKey(I => I.RolId);
        }
    }
}
