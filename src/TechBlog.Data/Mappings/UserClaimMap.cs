using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class UserClaimMap : IEntityTypeConfiguration<AppUserClaim>
{
    public void Configure(EntityTypeBuilder<AppUserClaim> b)
    {
        // Primary key
        b.HasKey(uc => uc.Id);

        // Maps to the AspNetUserClaims table
        b.ToTable("AspNetUserClaims");
    }
}