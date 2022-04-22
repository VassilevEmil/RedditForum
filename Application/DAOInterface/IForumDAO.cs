using Domain.Models;

namespace Application.DAOInterface;

public interface IForumDAO
{
    public Task<Post> CreatePost(Post post);
    public Task<ICollection<Post>> GetPosts();
    public Task<Post> GetPost(string Id);

    public Task<Post> Delete(string id);

    public Task<Post> Update(Post post);
    public Task<ICollection<User>> GetUserAsync();
    public Task<User> GetUser(string username);
    public Task<User> AddUser(User user);
    public Task DeleteUser(string id);
    public Task<User> GetUserById(string id);

    public Task Update(User user);
    
    


}