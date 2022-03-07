using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Services;

namespace WebApiTest.Controllers;

[ApiController]
public class LoginController : ControllerBase
{

    [HttpPost("v1/login")]
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        var token = tokenService.GenerateToken();
        return Ok(token);
    }

    [Authorize(Roles = "user")]
    [HttpGet("v1/users")]
    public IActionResult GetUser()
        => Ok(User.Identity.Name);


    [Authorize(Roles = "author")]
    [HttpGet("v1/authors")]
    public IActionResult GetAuthor()
        => Ok(User.Identity.Name);


    [HttpGet("v1/admins")]
    public IActionResult GetAdmin()
        => Ok(User.Identity.Name);





}