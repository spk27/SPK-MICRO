using System;
using System.Threading;
using Spk.Catalog.Application.Common.Bitacora;
using Spk.Catalog.Application.Common.Interfaces;

namespace Spk.Catalog.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key, ICatalogDbContext context, CancellationToken cancellationToken)
            : base($"Entidad '{name}' ({key}) no fue encontrada.")
        {
            ExceptionAudit.Send("", $"Entidad '{name}' ({key}) no fue encontrada.", context, cancellationToken);
        }
        
        public NotFoundException(string name, object key)
            : base($"Entidad '{name}' ({key}) no fue encontrada.")
        { }
    }
}