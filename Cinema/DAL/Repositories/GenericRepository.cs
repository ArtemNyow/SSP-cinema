using DAL.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
{
    protected readonly DbSet<T> _dbSet;
    private readonly CinemaDbContext _dbContext;
    
    public GenericRepository(CinemaDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }
    
    public async Task<T> GetAsync(long id)
    {
        var item = await _dbSet.FindAsync(id);
        if (item is null)
        {
            //TODO
            throw new KeyNotFoundException();
        }

        return item;
    }
    
    public async Task<T> AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        var entry = await _dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public T Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = _dbSet.Update(entity);
        
        return entry.Entity;
    }

    public async Task<T> DeleteAsync(long id)
    {
        var item = await GetAsync(id);
        var entry = _dbSet.Remove(item);

        return entry.Entity;
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}