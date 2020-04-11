using Microsoft.EntityFrameworkCore;
using Spk.Catalog.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Common.Interfaces
{
    public interface ICatalogDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<ProductCategory> ProductsCategories { get; set; }

        DbSet<Audit> Audits { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
