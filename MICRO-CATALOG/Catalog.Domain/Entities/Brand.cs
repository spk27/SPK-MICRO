using System;
using System.Collections.Generic;

namespace Spk.Catalog.Domain.Entities {

    public class Brand {

        public long BrandId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}