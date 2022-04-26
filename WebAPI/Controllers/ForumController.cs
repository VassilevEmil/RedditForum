using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class ForumController : ControllerBase
{
    private IForum iForum;

    public ForumController(IForum iForum)
    {
        this.iForum = iForum;
    }
    
    
    //getAll 

    [HttpGet]

    public async Task<ActionResult<ICollection<Post>>> GetAll()
    {
        try
        {
            ICollection<Post> posts = await iForum.GetPosts();
           return Ok(posts);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    //create

    [HttpPost]
    public async Task<ActionResult<ICollection<Post>>> Create([FromBody] Post post)
    {
        try
        {
            Post added = await iForum.CreatePost(post);
            return Ok(added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    //delete by id
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<ICollection<Post>>> DeleteById([FromRoute] string id)
    {
        try
        {
            await iForum.DeletePost(id);
            return Ok("Post deleted" + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //update

    [HttpPatch]

    public async Task<ActionResult<ICollection<Post>>> Update([FromBody] Post post)
    {
        try
        {
            await iForum.UpdatePost(post);
            return Ok("Updated " + post);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Post>> GetById([FromRoute]string id)
    {
        try
        {
            Post posts = await iForum.GetPost(id);
            return Ok(posts);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}