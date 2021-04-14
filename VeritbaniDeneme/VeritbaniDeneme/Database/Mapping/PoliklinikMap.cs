using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Mapping
{
    public class PoliklinikMap : IEntityTypeConfiguration<Poliklinik>
    {
        public void Configure(EntityTypeBuilder<Poliklinik> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Ad).HasMaxLength(50).IsRequired();

            builder.HasMany(I => I.Doktorlar)
                .WithOne(I => I.Poliklinik)
                .HasForeignKey(I => I.PoliklinikId);
        }
    }
}
