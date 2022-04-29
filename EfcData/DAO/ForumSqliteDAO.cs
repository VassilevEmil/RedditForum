using System.Diagnostics.CodeAnalysis;
using Application.DAOInterface;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class ForumSqliteDAO : IForumDAO
{

    private ForumContext context;

    public ForumSqliteDAO(ForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreatePost(Post post)
    {
        try
        {
            Post? create = post;
            create.WrittenBy = await context.Users.FirstOrDefaultAsync(p => p.Id.Equals(post.WrittenBy.Id));


            await context.Posts.AddAsync(create);
            await context.SaveChangesAsync();
            return create;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
      
    }

    public async Task<ICollection<Post>> GetPosts()
    {
        ICollection<Post> posts = await context.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPost(string Id)
    {
        Post? post = await context.Posts.FindAsync(Id);
        return post;
    }

    public async Task<Post> Delete(string id)
    {
        Post? delete = await context.Posts.FindAsync(id);
        if (delete is null)
        {
            throw new Exception($"Post with {id} cannot be found");
        }

        context.Posts.Remove(delete);
        context.SaveChangesAsync();
        return delete;

    }

    public async Task<Post> Update(Post post)
    {
        Post update = await context.Posts.FirstOrDefaultAsync(t => t.Id.Equals(post));
        context.Posts.Update(update);
        await context.SaveChangesAsync();
        return update;
    }

    public async Task<ICollection<User>> GetUserAsync()
    {
        ICollection<User> users = await context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(string username)
    {
        User? user = await context.Users.FirstOrDefaultAsync(t=>t.UserName.Equals(username));
        return user;
    }

    public async Task<User> AddUser(User user)
    {
        EntityEntry<User> add = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return add.Entity;
    }

    public async Task DeleteUser(string id)
    {
       
            User? user = await context.Users.FindAsync();
            if (user is null)
            {
                throw new Exception($"user with id {id} doesnt exist");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        
        
    }

    public async Task<User> GetUserById(string id)
    {
        User? user = await context.Users.FindAsync(id);
        if (user is null)
        {
            throw new Exception($"user doesnt exist");
        }

        return user;
    }

    public async Task Update(User user)
    {
        User? update = await context.Users.FirstAsync(t => t.UserName.Equals(user));
        context.Users.Update(update);
        await context.SaveChangesAsync();
    }
}
    