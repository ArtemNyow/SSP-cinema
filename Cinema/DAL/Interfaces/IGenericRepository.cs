using Domain.Models;

namespace DAL.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task<T> GetAsync(long id);
    Task<T> AddAsync(T entity);
    T Update(T entity);
    Task<T> DeleteAsync(long id);
    Task SaveAsync();
}