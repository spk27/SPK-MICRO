using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

            builder.ToTable("ProductCategory", "Catalog");

            builder.HasKey(p => new { p.ProductId, p.CategoryId })
                .IsClustered(false);

            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategories_Products");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategories_Territories");
        }
    }
}
