﻿using Domain.Contracts;
using Domain.Models;

namespace FileData.DataAccess;

public class FileDataDAO : IUserService
{
    private FileContext fileContext;

    public FileDataDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }


    public async Task<ICollection<User>> GetUserAsync(string username)
    {
        return fileContext.Forum.Users;
    }

    public async Task<User> GetUser(string username)
    {
       User user =  fileContext.Forum.Users.First(u => u.UserName == username);
       return user;
    }

    public async Task<User> AddUser(User user)
    { 
        if (fileContext.Forum.Users.Any(t=>t.UserName.Equals(user.UserName)))
        {
            throw new Exception("Username already in use!");
        }
        else
        {
            
            fileContext.Forum.Users.Add(user);
            await fileContext.SaveChangesAsync();
            return user;
        }

    }

    public async Task DeleteUser(string id)
    {
        User user = fileContext.Forum.Users.First(u => u.Id == id);
        fileContext.Forum.Users.Remove(user);
        fileContext.SaveChangesAsync();
    }

    public async Task<User> GetUserById(string id)
    {
        User user = fileContext.Forum.Users.First(t => t.Id == id);
        return user;
    }
}
    
