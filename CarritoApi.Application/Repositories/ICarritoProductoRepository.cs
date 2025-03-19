using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Repositories
{
    public interface ICarritoProductoRepository : IBaseRepository<CarritoProducto>
    {
        Task<CarritoProducto?> VerificarExistenciaProductoEnCarrito(int carritoId, int productoId);
    }
}
