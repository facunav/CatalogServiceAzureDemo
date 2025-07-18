using Catalog.Application.DTOs;

namespace Catalog.Application.Interfaces
{
    /// <summary>
    /// Servicio para manejar operaciones relacionadas con productos.
    /// </summary>
    public interface IProductoService
    {
        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        Task<IEnumerable<ProductoDto>> GetAllAsync();

        /// <summary>
        /// Guarda un producto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddAsync(ProductoDto dto);
    }
}
