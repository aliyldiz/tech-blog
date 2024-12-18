using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TechBlog.Core.Entities;
using TechBlog.Data.Context;
using TechBlog.Data.Repositories.Abstractions;

namespace TechBlog.Data.Repositories.Concretes;

public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() 
{
    private readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    private DbSet<T> Table
    {
        get => _dbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Table;
        if (predicate != null)
            query = query.Where(predicate);

        if (includeProperties.Any())
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
        return await query.ToListAsync();

    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Table;
        query = query.Where(predicate);

        if (includeProperties.Any())
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
        return await query.SingleAsync();
    }

    public async Task<T> GetByGuidAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run((() => Table.Update(entity)));
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.AnyAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        return await Table.CountAsync(predicate);
    }
}