using CarritoApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApi.Domain.Entities
{
    public class CarritoProducto : BaseEntity
    {
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; } = null!;

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;

        public int Cantidad { get; set; } 
    }
}
