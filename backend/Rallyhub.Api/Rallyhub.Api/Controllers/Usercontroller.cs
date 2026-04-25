using Microsoft.AspNetCore.Mvc;
using Rallyhub.Repository.Entity;
using Rallyhub.Service.UserService;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Usercontroller : ControllerBase
{
    private readonly IService _userService;
    public Usercontroller(IService userService)
    {
        _userService = userService;
    }

    // [HttpPost]
    // public Task<IActionResult> Register()
    // {
    //     return 
    // }
}