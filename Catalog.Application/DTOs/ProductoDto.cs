﻿namespace Catalog.Application.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Categoria { get; set; } = default!;
    }
}
