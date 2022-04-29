using Application.DAOInterface;
using Domain.Contracts;
using Domain.Models;

namespace EfcData;

public class ForumSqliteDAO : IForumDAO
{
    public Task<Post> CreatePost(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Post>> GetPosts()
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPost(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Update(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(string id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(string id)
    {
        throw new NotImplementedException();
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }
}
    