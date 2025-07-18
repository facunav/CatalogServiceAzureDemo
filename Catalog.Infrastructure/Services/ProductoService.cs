using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var productos = await _repository.GetAllAsync();

            return productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria
            });
        }

        public async Task AddAsync(ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Categoria = dto.Categoria
            };
            await _repository.AddAsync(producto);
        }
    }
}
