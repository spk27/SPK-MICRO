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
            
            builder.Property(p => p.OldPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12,3)");
            
            builder.Property(p => p.NewPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12,3)");

            builder.Property(p => p.Weight)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(8,2)");

            builder.Property(p => p.Length)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(8,2)");

            builder.Property(p => p.Width)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(8,2)");

            builder.Property(p => p.Height)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(8,2)");
            
            builder.Property(p => p.StockQuantity)
                .HasDefaultValue(0);
            
            builder.Property(p => p.MinStockQuantity)
                .HasDefaultValue(0);
            
            builder.Property(p => p.DisplayStockQuantity)
                .HasDefaultValue(true);
            
            builder.Property(p => p.NotifyForQuantityBelow)
                .HasDefaultValue(false);

            builder.Property(p => p.MarkAsNew)
                .HasDefaultValue(false);

            builder.Property(p => p.Viewed)
                .HasDefaultValue(0);
            
            builder.Property(p => p.ReviewsCount)
                .HasDefaultValue(0);
                
            builder.Property(p => p.RatingAverage)
                .HasColumnType("decimal(8,2)");

            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brand");
        }
    }
}
