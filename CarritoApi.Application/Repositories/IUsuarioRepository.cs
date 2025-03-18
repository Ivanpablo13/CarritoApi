using CarritoApi.Domain.Entities;

namespace CarritoApi.Application.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByDniAsync(string dni);
    }
}
