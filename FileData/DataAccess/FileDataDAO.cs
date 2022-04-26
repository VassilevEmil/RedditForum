using Domain.Contracts;
using Domain.Models;
using Application.DAOInterface;

namespace FileData.DataAccess;

public class FileDataDAO : IForumDAO
{
    private FileContext fileContext;

    public FileDataDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }


    public Task<Post> Update(Post post)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<User>> GetUserAsync()
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

    public async Task Update(User user)
    {
        User userUpdate = fileContext.Forum.Users.First(t => t.Id.Equals(user.Id));
        userUpdate.UserName = user.UserName;
        userUpdate.Password = user.Password;
        userUpdate.Role = user.Role;
        userUpdate.City = user.City;
        userUpdate.BirthDate = user.BirthDate;
        fileContext.SaveChangesAsync();
    }


    public async Task<Post> CreatePost(Post post){
       fileContext.Forum.AddPost.Add(post);
       await fileContext.SaveChangesAsync();
       return post;
   }

   public async Task<ICollection<Post>> GetPosts()
   {
       return fileContext.Forum.AddPost;
   }

   public async Task<Post> GetPost(string Id)
   {
       Post post = fileContext.Forum.AddPost.First(t => t.Id == Id);
       return post;
   }

   public Task<Post> Delete(string id)
   {
       throw new NotImplementedException();
   }

   public Task DeletePost(string id)
   {
       throw new NotImplementedException();
   }

   public Task UpdatePost(Post post)
   {
       throw new NotImplementedException();
   }
}
    
