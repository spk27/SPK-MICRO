using System;
using System.Collections.Generic;
using Spk.Catalog.Domain.Common;

namespace Spk.Catalog.Domain.Entities {
    public class Product : AuditableEntity {

        public Product()
        {
            Categories = new HashSet<ProductCategory>();
            Medias = new HashSet<ProductMedia>();
        }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockQuantity { get; set; }
        public bool? DisplayStockQuantity  { get; set; }
        public bool? NotifyForQuantityBelow   { get; set; }
        public int? OrderMinimumQuantity { get; set; }
        public int? OrderMaximumQuantity { get; set; }
        public bool? MarkAsNew { get; set; }
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public DateTime? AvailableStartDateTimeUtc { get; set; }
        public DateTime? AvailableEndDateTimeUtc { get; set; }
        public int? Viewed { get; set; }
        public int? ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
        public long? BrandId { get; set; }

        public Brand Brand { get; set; }
        public ICollection<ProductCategory> Categories { get; private set; }
        public ICollection<ProductMedia> Medias { get; set; }

    }
}