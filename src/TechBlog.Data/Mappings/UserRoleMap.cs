using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> b)
    {
        // Primary key
        b.HasKey(r => new { r.UserId, r.RoleId });

        // Maps to the AspNetUserRoles table
        b.ToTable("AspNetUserRoles");

        b.HasData(new AppUserRole
        {
            UserId = Guid.Parse("C770E968-BB99-4CBF-951A-9AFA05C50B00"),
            RoleId = Guid.Parse("6B8511FE-807C-4B66-A09F-98DB7AE534BB"),
        }, new AppUserRole
        {
            UserId = Guid.Parse("08D35685-74F3-4319-9829-3E811BC93F85"),
            RoleId = Guid.Parse("A07812D1-29C0-42D1-93F4-458DE53C4419"),
        });
    }
}