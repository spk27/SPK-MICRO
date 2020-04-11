using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        private readonly ICatalogDbContext _context;

        public RequestLogger(ILogger<TRequest> logger, ICatalogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Catálogo --> Solicitud: {Name} {@Request}", 
                name, request);

            _context.Audits.Add(new Audit {
                Date = DateTime.Now,
                Action = name,
                IsError = false,
                Message = $"Se ha llamado a la accion con los siguientes parámetros: \n {request.ToString()}"
            });
            
            await _context.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
