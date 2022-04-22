using Domain.Models;


namespace Domain.Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetUserAsync();
    public Task<User> GetUser(string username);
    public Task<User> AddUser(User user);
    public Task DeleteUser(string id);
    public Task<User> GetUserById(string id);

    public Task Update(User user);
}