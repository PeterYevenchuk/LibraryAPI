using LibraryAPI.Auth.Service;
using LibraryAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    [Route("admin")]
    [Authorize(Policy = "OnlyForAdmin")]
    public IActionResult GetForAdmin()
    {
        return Ok("Only for admin endpoint test");
    }

    [HttpGet]
    [Route("manager")]
    [Authorize(Policy = "OnlyForManager")]
    public IActionResult GetForManager()
    {
        return Ok("Only for manager endpoint test");
    }

    [HttpGet]
    [Authorize]
    [Route("logout")]
    public IActionResult Loguot()
    {
        return Ok("Logout success");
    }

    [HttpPost]
    [Route("login")]
    public IActionResult ValidateUser([FromBody] AuthenticationRequest userAuthData)
    {
        return Ok(_authService.AuthenticateUser(userAuthData));
    }
}
