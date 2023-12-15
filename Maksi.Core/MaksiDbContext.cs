using System.Data.Common;
using Maksi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Maksi.Core;

public class MaksiDbContext : DbContext
{
    public MaksiDbContext(DbContextOptions<MaksiDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
}