using AuthorizationAndAuthentication.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationAndAuthentication.Persistence;
public class AuthDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
    : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        builder.Entity<Role>().HasIndex(r => r.Name).IsUnique();


        builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        builder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.Roles).HasForeignKey(ur => ur.UserId);
        builder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(u => u.Users).HasForeignKey(ur => ur.RoleId);
    }
}