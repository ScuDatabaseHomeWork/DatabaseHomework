using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritbaniDeneme.Database.Entities;

namespace VeritbaniDeneme.Database.Mapping
{
    public class RandevuMap:IEntityTypeConfiguration<Randevu>
    {
        public void Configure(EntityTypeBuilder<Randevu> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Tarihi).IsRequired();

            builder.HasIndex(I => new { I.DoktorId, I.Tarihi }).IsUnique(unique:true);
        }
    }
}
