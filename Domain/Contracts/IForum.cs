using Domain.Models;

namespace Domain.Contracts;

public interface IForum
{
    public Task<Post> CreatePost(Post post);
    public Task<ICollection<Post>> GetPosts();
    public Task<Post> GetPost(string Id);
    public Task DeletePost(string id);

    public Task UpdatePost(Post post);



}