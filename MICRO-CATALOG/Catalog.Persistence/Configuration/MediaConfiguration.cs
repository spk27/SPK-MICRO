using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spk.Catalog.Domain.Entities;
using Spk.Catalog.Domain.Enums;

namespace Spk.Catalog.Persistence.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {

            builder.ToTable("Media", "Catalog");

            builder.Property(p => p.MediaId).HasColumnName("MediaID");

            builder.Property(p => p.FileName)
                .IsRequired();

            builder.Property(p => p.Caption).HasMaxLength(255);

            builder.Property(p => p.MediaType)
                .HasConversion(
                    m => m.ToString()
                    ,m => (MediaType)Enum.Parse(typeof(MediaType), m) 
                );
        }
    }
}
