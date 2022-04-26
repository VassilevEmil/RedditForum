using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using Domain.Contracts;
using Domain.Models;


namespace RESTClient;

public class HttpClientSerivce : IUserService,  IForum
{
    public async Task<ICollection<User>> GetUserAsync()
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get,"/user");
        
            ICollection<User> user = JsonSerializer.Deserialize<ICollection<User>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return user;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddUser(User user)
    {
        try
        {
            string client = await ServerAPI.getContent(Methods.Post, "/user", user);
            User user1 = JsonSerializer.Deserialize<User>(client, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return user1;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
        
    }

    public async Task DeleteUser(string id)
    {
        try
        {
            string client = await ServerAPI.getContent(Methods.Delete, $"/user/{id}");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User> GetUserById(string id)
    {
        try
        {
            string client = await ServerAPI.getContent(Methods.Get, $"/user/{id}");
            User user = JsonSerializer.Deserialize<User>(client, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return user;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task Update(User user)
    {
        try
        {
            string client = await ServerAPI.getContent(Methods.Patch, "/user", user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task<Post> CreatePost(Post post)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Post, "/post", post);
            Post create = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return create;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<Post>> GetPosts()
    {
        try
        {
            string post = await ServerAPI.getContent(Methods.Get, "allposts");
            ICollection<Post> forum = JsonSerializer.Deserialize<ICollection<Post>>(post, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return forum;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
       
    }
    

    public async Task<Post> GetPost(string Id)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get, $"/post/{Id}");
            Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return post;
        }

        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeletePost(string id)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Delete, $"/post/{id}");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdatePost(Post post)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Patch, $"/post", post);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}