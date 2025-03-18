using CarritoApi.Domain.Common;

namespace CarritoApi.Domain.Entities
{
    public class Carrito : BaseEntity
    {
        public required int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Producto> Productos { get; set; } = [];
        public decimal Total { get; set; }
        public required int TipoCarrito { get; set; }
    }
}
