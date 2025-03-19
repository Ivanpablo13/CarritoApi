using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Repositories
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<List<Producto>> ObtenerProductosMasCaros(string dniUsuario, CancellationToken cancellationToken);
        
    }
}
