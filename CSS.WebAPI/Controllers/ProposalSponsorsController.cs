using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalSponsorModels;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers;
public class ProposalSponsorsController : BaseController
{
    private readonly IProposalSponsorService _proposalSponsorService;
    public ProposalSponsorsController(IProposalSponsorService proposalSponsorService)
    {
        _proposalSponsorService = proposalSponsorService;
    }

    [Authorize(Roles = nameof(RoleEnum.Sponsor))]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _proposalSponsorService.GetBySponsorAsync();
        if(result.Count() > 0)
            return Ok(result.AsQueryable());
        else throw new Exception($"--> error: You have not followed any proposal!");
    }

    [Route("/api/proposals/{id}/proposal-sponsors")]
    [HttpGet]
    public async Task<IActionResult> GetByProposal(Guid id) 
    {
        var result = await _proposalSponsorService.GetByProposalAsync(id);
        if(result.Any()) 
        {
            return Ok(result.AsQueryable());
        } else
        {
            throw new Exception($"--> error: proposal-sponsors list of proposal is empty! ProposalId: {id}");
        }
    }

    [Authorize(Roles = nameof(RoleEnum.Sponsor))]
    [HttpPost] 
    public async Task<IActionResult> Post([FromBody] ProposalSponsorCreateModel model)
    {
        var result = await _proposalSponsorService.CreateAsync(model);
        if(result is not null)
        {
            return StatusCode(StatusCodes.Status201Created, result);
        } else throw new Exception($"--> error: create Failed!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _proposalSponsorService.DeleteAsync(id);
        return NoContent();
    }
    
}