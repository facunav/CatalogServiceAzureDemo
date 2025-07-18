using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();
    }
}
