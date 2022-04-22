using Application.DAOInterface;
using Domain.Contracts;
using Domain.Models;

namespace Application.Impls;

public class ForumServiceImpl : IForum
{

    private IForumDAO iForumDao;

    public ForumServiceImpl(IForumDAO iForumDao)
    {
        this.iForumDao = iForumDao;
    }
    
    public async Task<Post> CreatePost(Post post)
    {
        return await iForumDao.CreatePost(post);
    }

    public async Task<ICollection<Post>> GetPosts()
    {
        return await iForumDao.GetPosts();
    }

    public async Task<Post> GetPost(string Id)
    {
        return await iForumDao.GetPost(Id);
    }

    public  Task DeletePost(string id)
    {
        return iForumDao.Delete(id);
    }

    public  Task UpdatePost(Post post)
    {
        return  iForumDao.Update(post);
    }

}