using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class ForumContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
   public DbSet<Forum> forums { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlite(@"Data Source = ../EfcData/Forum.db");
    }
    

    public void Seed()
    {
        if (Posts.Any()) return;
        if (Users.Any()) return;

        User[] users =
        {
            new User
            {
                UserName = "admin", Password = "admin", City = "Horsens", BirthDate = new DateTime(1995, 10, 03),
                Role = "admin"
            },
            new User()
            {
                UserName = "Emil", Password = "12345", City = "Copenhagen", Role = "user",
                BirthDate = new DateTime(1995, 10, 03)
            }
        };

        Post[] posts =
        {
            new Post()
            {
                Body = "write your first post"
            }
        };

        Forum forum = new Forum();
        forum.Users = users;
        forum.AddPost = posts;
        forums.AddRange(forum);
        SaveChangesAsync();
    }

    



}