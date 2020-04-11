using System;

namespace Spk.Catalog.Domain.Interfaces {
    public interface IProductPricesBussiness
    {
        bool IsOnLowStock(int MinimunStock, int CurrentStock);
    }
}