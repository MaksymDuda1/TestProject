using System.Data.Common;
using Maksi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Maksi.Core;

public class MaksiDbContext : DbContext
{
    public MaksiDbContext(DbContextOptions<MaksiDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Role>()
            .HasData(new Role()
            {
                Id = 1,
                Name = "Admin"
            });
        
        modelBuilder.Entity<Role>()
            .HasData(new Role()
            {
                Id = 2,
                Name = "Teacher"
            });
        
        modelBuilder.Entity<Role>()
            .HasData(new Role()
            {
                Id = 3,
                Name = "Student"
            });
        
        modelBuilder.Entity<Role>()
            .HasData(new Role()
            {
                Id = 4,
                Name = "Parent"
            });

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                Id = 1,
                Email = "admin",
                Password = "admin"
            });

        modelBuilder.Entity<UserRole>()
            .HasData(new UserRole()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            });

       base.OnModelCreating(modelBuilder);
    }

    

    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
}