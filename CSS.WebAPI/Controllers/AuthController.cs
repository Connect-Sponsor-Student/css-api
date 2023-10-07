using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.LoginModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;


public class AuthController : BaseController
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginRequestModel model) 
    {
        var result = await _userService.LoginAsync(model) ?? throw new Exception($"Login Failed!"); 
        return Ok(result);
    }
}