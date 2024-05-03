using Domain.Models;

namespace BLL.Interfaces
{
    public interface ICrud<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
    }
}
