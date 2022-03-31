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
    /*
    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetALl()
    {
        try
        {
            ICollection<User> users = await userService.GetUserAsync()
        }
    }
    */

}