using System;
using System.Collections.Generic;
using AutoMapper;
using Spk.Catalog.Application.Common.Mappings;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Application.Products.Queries.GetProductBasics {

    public class ProductBasicsVM : IMapFrom<Product> {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool LowStock { get; set; }
        public bool OnStock { get; set; }
        public bool IsNew { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductBasicsVM>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(
                    d => d.LowStock,
                    opt => opt.MapFrom(
                        s => s.StockQuantity <= s.MinStockQuantity && 0 < s.StockQuantity
                    ))
                .ForMember(
                    d => d.IsNew,
                    opt => opt.MapFrom(
                        s => s.MarkAsNewStartDateTimeUtc <= DateTime.Now && DateTime.Now <= s.MarkAsNewEndDateTimeUtc
                    ));
        }
    }
}