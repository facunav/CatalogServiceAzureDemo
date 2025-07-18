using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    /// <summary>
    /// Controlador para acceder a información de productos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        /// <summary>
        /// Constructor que inyecta el servicio de productos.
        /// </summary>
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductoDto>> Get()
        {
            return Ok(_productoService.GetAllAsync());
        }


        /// <summary>
        /// Guarda un producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(ProductoDto producto)
        {
            await _productoService.AddAsync(producto);
            return CreatedAtAction(nameof(Get), null);
        }
    }
}
