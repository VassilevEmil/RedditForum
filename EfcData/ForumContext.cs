using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class ForumContext : DbContext
{
    public DbSet<Post> posts { get; set; }
    public DbSet<User> users { get; set; }
  //  public DbSet<Forum> forums { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlite("Data Source = ../EfcData/Forum.db");
    }
    
}