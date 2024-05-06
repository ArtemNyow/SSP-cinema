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
    
    public IQueryable<T> GetAll(params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return query;
    }

    public async Task<T> GetAsync(long id, params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        var item = await query.FirstOrDefaultAsync(entity => entity.ID == id);
        if (item == null)
        {
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