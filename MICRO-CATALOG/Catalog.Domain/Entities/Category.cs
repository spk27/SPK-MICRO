using System;
using System.Collections.Generic;

namespace Spk.Catalog.Domain.Entities {

    public class Category {

        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; private set; }
    }
}