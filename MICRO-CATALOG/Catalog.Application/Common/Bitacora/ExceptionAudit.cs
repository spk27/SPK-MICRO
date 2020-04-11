
using System;
using System.Threading;
using System.Threading.Tasks;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Domain.Entities;

namespace Spk.Catalog.Application.Common.Bitacora {
  public static class ExceptionAudit {
    public static Task Send(string accion, string message, ICatalogDbContext _context, CancellationToken cancellationToken)
    {
        _context.Audits.Add(new Audit {
            Date = DateTime.Now,
            Action = accion,
            IsError = true,
            Message = message
        });
        
        _context.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
  }
}