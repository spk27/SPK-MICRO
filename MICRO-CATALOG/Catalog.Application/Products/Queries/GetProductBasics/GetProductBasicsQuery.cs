using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spk.Catalog.Application.Common.Exceptions;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Products.Queries.GetProductBasics {

    public class GetProductBasicsQuery : IRequest<ProductBasicsVM> {
        public long Id { get; set; }
        public class GetProductBasicsQueryHandler : IRequestHandler<GetProductBasicsQuery, ProductBasicsVM> {

            private readonly ICatalogDbContext _context;
            private readonly IMapper _mapper;
            public GetProductBasicsQueryHandler(ICatalogDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductBasicsVM> Handle(GetProductBasicsQuery request, CancellationToken cancellationToken) {

                var product = await _context.Products
                    .FindAsync(request.Id);

                if (product == null) {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                var vm = _mapper.Map<ProductBasicsVM>(product);

                return vm;
            }
        }
    }
}