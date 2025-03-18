using CarritoApi.Persistence.Context;
using CarritoApi.Application.Repositories;
using CarritoApi.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Repositories
{
    public class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T : BaseEntity<int>
    {
        public async Task<T> CreateAsync(T entity)
        {
            await context.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id) //Esto puede ser mejorado para solo mandar la entidad y que la borre directamente
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }


    }
}
