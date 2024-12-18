using AutoMapper;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.AutoMapper.Articles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto, Article>().ReverseMap();
    }
}