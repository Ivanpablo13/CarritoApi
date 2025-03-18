
using CarritoApi.Application.Repositories;
using CarritoApi.Domain.Entities;
using CarritoApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Repositories
{
    public class UsuarioRepository(DataContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
    {
        public async Task<Usuario?> GetByDniAsync(string dni)
        {
            return await context.Set<Usuario>().FirstOrDefaultAsync(x => x.Dni == dni);
        }
    }
}
