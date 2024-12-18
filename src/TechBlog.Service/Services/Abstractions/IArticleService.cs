using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entities;
namespace TechBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesAsync();
}