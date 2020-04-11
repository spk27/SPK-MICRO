using System;

namespace Spk.Catalog.Domain.Entities {
    public class ProductCategory {
        public long ProductId { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}