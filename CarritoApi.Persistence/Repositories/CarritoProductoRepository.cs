using CarritoApi.Application.Repositories;
using CarritoApi.Domain.Entities;
using CarritoApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Repositories
{
    public class CarritoProductoRepository(DataContext context) : BaseRepository<CarritoProducto>(context), ICarritoProductoRepository
    {
        public async Task<CarritoProducto?> VerificarExistenciaProductoEnCarrito(int carritoId, int productoId)
        {
            var carritoProductoExistente = await context.CarritoProducto
                .FirstOrDefaultAsync(cp => cp.CarritoId == carritoId && cp.ProductoId == productoId);

            return carritoProductoExistente;
        }



    }
}
