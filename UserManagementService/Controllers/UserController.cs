using Microsoft.AspNetCore.Mvc;
using UserManagementService.Models;

namespace UserManagementService.Controllers;

public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user, string password)
    {
        try
        {
            var registeredUser = await _userService.RegisterUserAsync(user, password);
            return Ok(registeredUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        try
        {
            var user = await _userService.LoginAsync(username, password);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}