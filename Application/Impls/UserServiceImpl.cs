using Application.DAOInterface;
using Domain.Contracts;
using Domain.Models;

namespace Application.Impls;

public class UserServiceImpl : IUserService
{

    private IForumDAO iForumDao;

    public UserServiceImpl(IForumDAO iForumDao)
    {
        this.iForumDao = iForumDao;
    }
    
    public async Task<ICollection<User>> GetUserAsync()
    {
        return await iForumDao.GetUserAsync();
    }

    public async Task<User> GetUser(string username)
    {
        return await iForumDao.GetUser(username);
    }

    public async Task<User> AddUser(User user)
    {
        return await iForumDao.AddUser(user);
    }

  
    public async  Task DeleteUser(string id)
    {
        await  iForumDao.DeleteUser(id);
    }

    public async Task<User> GetUserById(string id)
    {
        return await iForumDao.GetUserById(id);
    }

   
    public async Task Update(User user)
    {
        await iForumDao.Update(user);
    }
}