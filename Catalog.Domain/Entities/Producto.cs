namespace Catalog.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Categoria { get; set; } = default!;
    }
}
