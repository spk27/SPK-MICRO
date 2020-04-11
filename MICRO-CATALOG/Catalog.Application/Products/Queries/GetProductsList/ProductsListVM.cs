using System.Collections.Generic;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Application.Products.Queries.GetProductsList {

    public class ProductsListVM {
        public List<ProductsListDTO> Products { get; set; }
        public int Count { get; set; }
    }
}