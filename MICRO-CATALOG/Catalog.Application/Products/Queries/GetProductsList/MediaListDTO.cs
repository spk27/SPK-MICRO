using System;
using AutoMapper;
using Spk.Catalog.Application.Common.Mappings;
using Spk.Catalog.Domain.Entities;
using Spk.Catalog.Domain.Enums;

namespace Spk.Catalog.Application.Products.Queries.GetProductsList {

    public class MediaListDTO : IMapFrom<ProductMedia> {

        public string FileName { get; set; }
        public int DisplayOrder { get; set; }
        public string Source { get; set; }
        public string Caption { get; set; }
        public MediaType MediaType { get; set; }
        
        public void Mapping(Profile profile)
        {

            profile.CreateMap<ProductMedia, MediaListDTO>()
                .ForMember(d => d.FileName, opt => opt.MapFrom(s => s.Media.FileName))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Media.Source))
                .ForMember(d => d.Caption, opt => opt.MapFrom(s => s.Media.Caption))
                .ForMember(d => d.MediaType, opt => opt.MapFrom(s => s.Media.MediaType))
                ;
        }
    }
}