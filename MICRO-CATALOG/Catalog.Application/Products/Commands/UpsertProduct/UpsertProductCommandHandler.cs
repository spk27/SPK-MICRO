using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Spk.Catalog.Application.Common.Exceptions;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductCommandHandler : IRequestHandler<UpsertProductCommand, long>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public UpsertProductCommandHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<long> Handle(UpsertProductCommand request, CancellationToken cancellationToken)
        {
            Product entity;

            if (request.Id.HasValue)
            {
                entity = await _context.Products.FindAsync(request.Id.Value);

                if (entity == null) {
                    throw new NotFoundException(nameof(Product), request.Id, _context, cancellationToken);
                }
            }
            else
            {
                entity = new Product();

                _context.Products.Add(entity);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.OldPrice = request.OldPrice;
            entity.NewPrice = request.NewPrice;
            entity.StockQuantity = request.StockQuantity;
            entity.MinStockQuantity = request.MinStockQuantity;
            entity.DisplayStockQuantity  = request.DisplayStockQuantity;
            entity.NotifyForQuantityBelow   = request.NotifyForQuantityBelow;
            entity.OrderMinimumQuantity = request.OrderMinimumQuantity;
            entity.OrderMaximumQuantity = request.OrderMaximumQuantity;
            entity.MarkAsNew = request.MarkAsNew;
            entity.MarkAsNewStartDateTimeUtc = request.MarkAsNewStartDateTimeUtc;
            entity.MarkAsNewEndDateTimeUtc = request.MarkAsNewEndDateTimeUtc;
            entity.Weight = request.Weight;
            entity.Length = request.Length;
            entity.Width = request.Width;
            entity.Height = request.Height;
            entity.AvailableStartDateTimeUtc = request.AvailableStartDateTimeUtc;
            entity.AvailableEndDateTimeUtc = request.AvailableEndDateTimeUtc;
            entity.Viewed = request.Viewed;

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UpsertProductNotification { 
                ProductId = entity.ProductId
                ,Name = entity.Name
                ,Action = request.Id.HasValue ? "Edición" : "Creación"
            }
            , cancellationToken);

            return entity.ProductId;
        }
    }
}