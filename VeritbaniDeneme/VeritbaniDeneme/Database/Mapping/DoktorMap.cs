using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Mapping
{
    public class DoktorMap:IEntityTypeConfiguration<Doktor>
    {
        public void Configure(EntityTypeBuilder<Doktor> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Ad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Soyad).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Cinsiyet).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Telefon).HasMaxLength(15).IsRequired();

            builder.HasMany(I => I.Randevular)
                .WithOne(I => I.Doktor)
                .HasForeignKey(I => I.DoktorId);
        }
    }
}
