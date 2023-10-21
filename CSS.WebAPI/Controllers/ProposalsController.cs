using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

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

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _proposalService.GetAllAsync();
        return Ok(result.AsQueryable());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _proposalService.GetByIdAsync(id);
        return Ok(result);
    }

    [Authorize(Roles = nameof(RoleEnum.Student))]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProposalUpdateModel model)
    {
        var result = await _proposalService.UpdateAsync(model);
        return result ? throw new Exception($"--> Error: Update Proposal Failed! ProposalId: {model.Id}") 
        : NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _proposalService.DeleteAsync(id);
        if(result) return NoContent();
        else throw new Exception($"--> Error: Update Failed! ProposalId: {id}");
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AssignSponsor([FromRoute] Guid id, [FromForm] List<Guid> SponsorsId, [FromQuery] string proposalLink)
    {
        await _proposalService.AssignSponsor(id, SponsorsId, proposalLink);
        return Ok();
    }
}