using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spk.Catalog.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Products.Queries.GetProductsList {

    public class GetProductsListQuery : IRequest<ProductsListVM> {
        public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVM> {

            private readonly ICatalogDbContext _context;
            private readonly IMapper _mapper;
            public GetProductsListQueryHandler(ICatalogDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductsListVM> Handle(GetProductsListQuery request, CancellationToken cancellationToken) {

                var products = await _context.Products
                    .Include(p => p.Medias)
                    .ProjectTo<ProductsListDTO>(_mapper.ConfigurationProvider)
                    .Take(10)
                    .ToListAsync(cancellationToken);

                var vm = new ProductsListVM {
                    Products = products
                    ,Count = products.Count
                };

                return vm;
            }
        }
    }
}