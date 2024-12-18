using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
{
    public void Configure(EntityTypeBuilder<AppRoleClaim> b)
    {
        // Primary key
        b.HasKey(rc => rc.Id);

        // Maps to the AspNetRoleClaims table
        b.ToTable("AspNetRoleClaims");
    }
}