using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CatalogDbContext _context;

        public ProductoRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            _context.SaveChanges();
        }
    }
}
