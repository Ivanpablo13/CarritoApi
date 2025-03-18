using CarritoApi.Application.Repositories;
using CarritoApi.Domain.Entities;
using CarritoApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Repositories
{
    public class CarritoRepository(DataContext context) : BaseRepository<Carrito>(context), ICarritoRepository
    {
        public async Task<Carrito?> GetCompleteByIdAsync(int id)
        {
            return await context.Carritos
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
