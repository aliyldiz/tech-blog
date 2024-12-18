using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // builder.Property(x => x.Title).HasMaxLength(150);
        builder.HasData(new Article
        {
            Id = Guid.NewGuid(),
            Title = "Asp.Net Core Sample Article",
            Content = "Asp.Net Core This is a sample article for Asp.Net Core application. This article is created for testing purposes.",
            ViewCount = 15,
            CategoryId = Guid.Parse("93C4E345-4D7B-4E21-8F68-AB82E87271C9"),
            ImageId = Guid.Parse("7FADD6E2-4132-4DB8-A7F4-F1CBB7E3F180"),
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("C770E968-BB99-4CBF-951A-9AFA05C50B00"),
        },
        new Article
        {
            Id = Guid.NewGuid(),
            Title = "C# Sample Article",
            Content = "C# This is a sample article for C# programming language. This article is created for testing purposes.",
            ViewCount = 15,
            CategoryId = Guid.Parse("CC8F09B0-4AE1-456D-B494-F5D3363CC778"),
            ImageId = Guid.Parse("A6CA53AC-3E73-4BBD-869C-C400A6A0A964"),
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = Guid.Parse("08D35685-74F3-4319-9829-3E811BC93F85"),
        }
        );
    }
}