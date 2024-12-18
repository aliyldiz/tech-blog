using TechBlog.Data.Context;
using TechBlog.Data.Repositories.Abstractions;
using TechBlog.Data.Repositories.Concretes;

namespace TechBlog.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }
    
    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    
    IRepository<T> IUnitOfWork.GetRepository<T>() 
    {
        return new Repository<T>(_dbContext);
    }
}