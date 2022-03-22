using BlazorApp1.Services;

namespace Domain.Models;

public class Forum
{
    public ICollection<SubForum> SubForums { get; set; }
    public ICollection<User> Users { get; set; }
    
    public ICollection<Post> AddPost { get; set; }

    public Forum()
    {
       SubForums = new List<SubForum>();
        Users = new List<User>();
        AddPost = new List<Post>();
    }
}