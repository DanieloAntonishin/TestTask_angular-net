using Microsoft.EntityFrameworkCore;
using System;

namespace webapi;

public class MySqlDbContext: DbContext
{
    public DbSet<ShortenerUrl> ShortenerUrlEntities { get; set; }
    public DbSet<User> UserEntities { get; set; }
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)  // Add new Entitys "Table" to DB
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ShortenerUrl>();
        modelBuilder.Entity<User>();
        
    }
}
