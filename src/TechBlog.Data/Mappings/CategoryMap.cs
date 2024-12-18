using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category
        {
            Id = Guid.Parse("93C4E345-4D7B-4E21-8F68-AB82E87271C9"),
            Name = "Asp.Net Core",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new Category
        {
            Id = Guid.Parse("CC8F09B0-4AE1-456D-B494-F5D3363CC778"),
            Name = "C#",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        }
        );
    }
}