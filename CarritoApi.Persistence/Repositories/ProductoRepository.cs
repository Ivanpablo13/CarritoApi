using CarritoApi.Persistence.Context;
using CarritoApi.Domain.Entities;
using CarritoApi.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Repositories
{
    public class ProductoRepository(DataContext context) : BaseRepository<Producto>(context), IProductoRepository
    {
        public async Task<List<Producto>> ObtenerProductosMasCaros(string dniUsuario, CancellationToken cancellationToken)
        {
            return await context
                .Set<Carrito>()
                .Where(c => c.Usuario.Dni == dniUsuario)
                .SelectMany(c => c.Productos)
                .OrderByDescending(item => item.Precio)
                .Take(4)
                .ToListAsync(cancellationToken);
        }

    }
}
