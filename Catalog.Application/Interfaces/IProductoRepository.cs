using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces
{
    /// <summary>
    /// Repositorio de acceso a datos de productos.
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Devuelve todos los productos desde la fuente de datos.
        /// </summary>
        /// <returns>Lista de entidades Producto.</returns>
        Task<IEnumerable<Producto>> GetAllAsync();

        /// <summary>
        /// Guarda un producto.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        Task AddAsync(Producto producto);
    }
}
