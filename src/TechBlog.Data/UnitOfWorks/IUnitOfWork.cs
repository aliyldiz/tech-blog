using TechBlog.Core.Entities;
using TechBlog.Data.Repositories.Abstractions;

namespace TechBlog.Data.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync();
    int Save();
}