using CSS.Application.Services.Interfaces;
using CSS.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class RolesController : BaseController
{
    private readonly IRoleService _roleService;
    public RolesController(IRoleService _roleService)
    {
        this._roleService = _roleService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _roleService.GetAllAsync());
    }
}