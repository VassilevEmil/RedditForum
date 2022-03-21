﻿using Domain.Models;


namespace Domain.Contracts;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
    public Task<User> GetUser(string username);
    public Task<User> AddUser(User user);
    public Task DeleteUser(string id);
    public Task<User> GetUserById(string id);
}