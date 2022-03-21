using Domain.Contracts;
using Domain.Models;



namespace FileData.DataAccess;

public class FileDataDAO : IUserService
{
    private FileContext fileContext;

    public FileDataDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }


    public Task<User> GetUserAsync(string username)
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
}
    
