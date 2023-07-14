using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicine.WebApi.Persistence.EntityTypeConfigurations
{
    public class MedicineEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Medicine>
    {
        public void Configure(EntityTypeBuilder<Entities.Medicine> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Structure)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

