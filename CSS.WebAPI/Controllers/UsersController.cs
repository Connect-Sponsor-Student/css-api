using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class UsersController : BaseController
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserCreateModel model)
    {
        var result = await _userService.CreateAsync(model) ?? throw new Exception($"Create Failed!");
        return StatusCode(StatusCodes.Status201Created, result);
    } 
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserUpdateModel model)
    {
        var result = await _userService.UpdateAsync(model);
        return StatusCode(StatusCodes.Status204NoContent, result);
    }
}