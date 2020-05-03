using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Persistence.Configurations
{
    public class ProductMediaConfiguration : IEntityTypeConfiguration<ProductMedia>
    {
        public void Configure(EntityTypeBuilder<ProductMedia> builder)
        {

            builder.ToTable("ProductMedia", "Catalog");

            builder.HasKey(p => new { p.ProductId, p.MediaId })
                .IsClustered(false);

            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.MediaId).HasColumnName("MediaID");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Medias)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMedias_Products");
        }
    }
}
