using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Mapping
{
    public class HastaMap:IEntityTypeConfiguration<Hasta>
    {
        public void Configure(EntityTypeBuilder<Hasta> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Ad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Soyad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.AnaAdi).HasMaxLength(50).IsRequired();
            builder.Property(I => I.BabaAdi).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Telefon).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Tcno).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Parola).HasMaxLength(50).IsRequired();

            builder.HasMany(I => I.Randevular)
                .WithOne(I => I.Hasta)
                .HasForeignKey(I => I.HastaId);
        }
    }
}
