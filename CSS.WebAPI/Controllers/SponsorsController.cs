using CSS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class SponsorsController : BaseController
{
    private readonly ISponsorService _sponsorService;
    public SponsorsController(ISponsorService sponsorService)
    {
        _sponsorService = sponsorService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _sponsorService.GetAllSponsor());
    }
}