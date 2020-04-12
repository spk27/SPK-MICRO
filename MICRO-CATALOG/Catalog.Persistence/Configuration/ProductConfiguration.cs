using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spk.Catalog.Domain.Entities;
using Spk.Catalog.Domain.Rules;

namespace Spk.Catalog.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product", "Catalog");

            builder.Property(p => p.ProductId).HasColumnName("ProductID");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(ProductRules.MaxLengthProductName);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12,3)");
        }
    }
}
