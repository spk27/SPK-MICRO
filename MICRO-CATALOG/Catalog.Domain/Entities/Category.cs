using System;
using System.Collections.Generic;

namespace Spk.Catalog.Domain.Entities {

    public class Category {

        public Category()
        {
            Products = new HashSet<ProductCategory>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory> Products { get; private set; }
    }
}