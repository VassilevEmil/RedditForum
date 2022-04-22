using System.Text.Json;
using Domain.Contracts;
using Domain.Models;


namespace RESTClient;

public class HttpClientSerivce : IUserService, IDisposable
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

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}