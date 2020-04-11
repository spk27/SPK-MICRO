using System;
using Spk.Catalog.Domain.Interfaces;

namespace Spk.Catalog.Application.Products.Bussiness {
    public class ProductPricesBussiness : IProductPricesBussiness {

        public bool IsOnLowStock(int MinimunStock, int CurrentStock) {
            return CurrentStock <= MinimunStock && 0 < CurrentStock ? true : false;
        }
    }
}