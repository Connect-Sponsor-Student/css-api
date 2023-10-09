using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class ProposalsController : BaseController
{
    private readonly IProposalService _proposalService;
    public ProposalsController(IProposalService proposalService)
    {
        _proposalService = proposalService;
    }

    [Authorize(Roles = nameof(RoleEnum.Student))]
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ProposalCreateModel model)
    {
        var result = await _proposalService.CreateAsync(model);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}