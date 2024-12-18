using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechBlog.Data.Context;
using TechBlog.Data.Repositories.Abstractions;
using TechBlog.Data.Repositories.Concretes;
using TechBlog.Data.UnitOfWorks;

namespace TechBlog.Data.Extensions;

public static class DataLayerExtensions
{
    public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}