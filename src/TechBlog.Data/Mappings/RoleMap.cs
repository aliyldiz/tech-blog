using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> b)
    {
        // Primary key
        b.HasKey(r => r.Id);

        // Index for "normalized" role name to allow efficient lookups
        b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

        // Maps to the AspNetRoles table
        b.ToTable("AspNetRoles");

        // A concurrency token for use with the optimistic concurrency checking
        b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.Name).HasMaxLength(256);
        b.Property(u => u.NormalizedName).HasMaxLength(256);

        // The relationships between Role and other entity types
        // Note that these relationships are configured with no navigation properties

        // Each Role can have many entries in the UserRole join table
        b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

        // Each Role can have many associated RoleClaims
        b.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

        b.HasData(new AppRole
        {
            Id = Guid.Parse("6B8511FE-807C-4B66-A09F-98DB7AE534BB"),
            Name = "Superadmin",
            NormalizedName = "SUPERADMIN",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        }, new AppRole
        {
            Id = Guid.Parse("A07812D1-29C0-42D1-93F4-458DE53C4419"),
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        }, new AppRole
        {
            Id = Guid.Parse("85B9F86C-6000-48C1-ADFD-F794989BE093"),
            Name = "User",
            NormalizedName = "USER",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
    }
}