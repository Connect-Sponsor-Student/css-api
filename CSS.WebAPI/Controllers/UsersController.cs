using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.EmailUtilities;
using CSS.Application.ViewModels.UserModels;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class UsersController : BaseController
{
    private readonly IUserService _userService;
    private readonly IEmailHelper _emailHelper;
    public UsersController(IUserService userService, IEmailHelper emailHelper)
    {
        _userService = userService;
        _emailHelper = emailHelper;
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _userService.GetAllAsync();
    return Ok(result.AsQueryable());
    }

    [HttpPut("{id}/reddem")]
    public async Task<IActionResult> ReddemCode([FromRoute] Guid id, [FromQuery] string reddemCode)
    {
        await _userService.ReddemCode(id, reddemCode);
        return NoContent();
    }

   
    [HttpGet("{email}")]    
    public async Task<IActionResult>GetUserByEmail(string email)
    {
        var check= await _userService.FindUserByEmail(email);
        return Ok(check);
        
    }

   
}