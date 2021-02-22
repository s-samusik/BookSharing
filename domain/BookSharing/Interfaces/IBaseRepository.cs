using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);
    }
}
