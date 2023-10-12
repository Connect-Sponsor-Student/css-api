using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ServiceModels;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CSS.WebAPI.Controllers;
public class ServicesController : BaseController
{
    private readonly IServiceTypeService _serviceType;
    public ServicesController(IServiceTypeService serviceType)
    {
        _serviceType = serviceType;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        return Ok((await _serviceType.GetAllAsync()).AsQueryable());
    } 
    [Authorize(Roles = nameof(RoleEnum.Admin))]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ServiceCreateModel model)
    {
        var result = await _serviceType.CreateAsync(model);
        if(result is not null)
            return StatusCode(StatusCodes.Status201Created, result);
        else throw new Exception($"--> Error: Create ServiceType Failed!");

    }
}