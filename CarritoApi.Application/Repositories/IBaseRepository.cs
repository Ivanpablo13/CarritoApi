using CarritoApi.Domain.Common;

namespace CarritoApi.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
