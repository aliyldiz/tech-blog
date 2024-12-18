using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Service.Services.Concretes;

namespace TechBlog.Service.Extensions;

public static class ServiceLayerExtensions
{
    public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddScoped<IArticleService, ArticleService>();
        
        services.AddAutoMapper(assembly);
        
        return services;
    }
}