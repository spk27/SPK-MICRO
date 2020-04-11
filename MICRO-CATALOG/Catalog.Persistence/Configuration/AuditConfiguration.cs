using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Persistence.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {

            builder.ToTable("Audit", "Catalog");

            builder.Property(a => a.Id).HasColumnName("ID");

            builder.Property(a => a.Date).HasColumnType("datetime");

            builder.Property(a => a.User).HasMaxLength(50);

            builder.Property(a => a.Action).HasMaxLength(255);

            builder.Property(a => a.IsError).HasColumnType("bit");

            builder.Property(a => a.Message);
        }
    }
}
