using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechBlog.Core.Entities;
using TechBlog.Entity.Entities;

namespace TechBlog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> b)
    {
        // Primary key
        b.HasKey(u => u.Id);

        // Indexes for "normalized" username and email, to allow efficient lookups
        b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
        b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

        // Maps to the AspNetUsers table
        b.ToTable("AspNetUsers");

        // A concurrency token for use with the optimistic concurrency checking
        b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.UserName).HasMaxLength(256);
        b.Property(u => u.NormalizedUserName).HasMaxLength(256);
        b.Property(u => u.Email).HasMaxLength(256);
        b.Property(u => u.NormalizedEmail).HasMaxLength(256);

        // The relationships between User and other entity types
        // Note that these relationships are configured with no navigation properties

        // Each User can have many UserClaims
        b.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

        // Each User can have many UserLogins
        b.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

        // Each User can have many UserTokens
        b.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

        // Each User can have many entries in the UserRole join table
        b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

        var superAdmin = new AppUser
        {
            Id = Guid.Parse("C770E968-BB99-4CBF-951A-9AFA05C50B00"),
            UserName = "superadmin@gmail.com",
            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
            Email = "superadmin@gmail.com",
            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
            PhoneNumber = "+905552223322",
            FirstName = "Ali",
            LastName = "Yildiz",
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId = Guid.Parse("7FADD6E2-4132-4DB8-A7F4-F1CBB7E3F180"),
        };
        superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123456");

        var admin = new AppUser
        {
            Id = Guid.Parse("08D35685-74F3-4319-9829-3E811BC93F85"),
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            PhoneNumber = "+905552228855",
            FirstName = "Admin",
            LastName = "User",
            PhoneNumberConfirmed = false,
            EmailConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageId = Guid.Parse("A6CA53AC-3E73-4BBD-869C-C400A6A0A964"),
        };
        
        b.HasData( superAdmin, admin);

    }
    private string CreatePasswordHash(AppUser user, string password)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.HashPassword(user, password);
    }
}