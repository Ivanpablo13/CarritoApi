using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Repositories
{
    public interface ICarritoRepository : IBaseRepository<Carrito>
    {
        Task<Carrito> GetCompleteByIdAsync(int id);
    }
}
