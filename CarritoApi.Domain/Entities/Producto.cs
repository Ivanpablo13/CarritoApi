using CarritoApi.Domain.Common;

namespace CarritoApi.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int CarritoId { get; set; }
    }
}
