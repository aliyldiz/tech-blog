using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image
        {
            Id = Guid.Parse("7FADD6E2-4132-4DB8-A7F4-F1CBB7E3F180"),
            FileName = "images/testimage",
            FileType = "jpg",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new Image
        {
            Id = Guid.Parse("A6CA53AC-3E73-4BBD-869C-C400A6A0A964"),
            FileName = "images/csimage",
            FileType = "png",
            CreatedBy = "Admin",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        });
    }
}