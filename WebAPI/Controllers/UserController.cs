using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    
    //get all users
    
    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetUser()
    {
        try
        {
            ICollection<User> users = await userService.GetUserAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //add user => create
    [HttpPost]

    public async Task<ActionResult<User>> AddUser([FromBody] User user)
    {
        try
        {
            User added = await userService.AddUser(user);
            return Created($"/todos/{added.Id}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //get by id

    [HttpGet]
    [Route("username/{username}")]

    public async Task<ActionResult<ICollection<User>>> GetUserByUsername([FromRoute]string username)
    {
        try
        {
            User user = await userService.GetUser(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    //delete user by id
    
    [HttpDelete]
    [Route(("{id}"))]

    public async Task<ActionResult<ICollection<User>>> DeleteUserById([FromRoute]string id)
    {
        try
        {
            await userService.DeleteUser(id);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]

    public async Task<ActionResult> Update([FromBody] User user)
    {
        try
        {
            await userService.Update(user);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]

    public async Task<ActionResult<ICollection<User>>> GetUserById([FromRoute]string id)
    {
        try
        {
            User user = await userService.GetUserById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}