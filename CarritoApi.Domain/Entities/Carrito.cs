using CarritoApi.Domain.Common;

namespace CarritoApi.Domain.Entities
{
    public class Carrito : BaseEntity
    {
        public required int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public ICollection<CarritoProducto> CarritoProductos { get; set; } = new List<CarritoProducto>();

        public decimal Total { get; set; }
        public required int TipoCarrito { get; set; }
    }
}
