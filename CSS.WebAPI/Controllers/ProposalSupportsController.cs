using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.ProposalServiceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CSS.WebAPI.Controllers;
[Route("/api/proposals/{id}/proposal-supports")]
public class ProposalSupportsController : BaseController
{
    private readonly IProposalSupportService _proposalSupportService;
    public ProposalSupportsController(IProposalSupportService proposalSupportService)
    {
        _proposalSupportService = proposalSupportService;
    }

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProposalSupportCreateModel model, [FromRoute] Guid id)
    {
        var result = await _proposalSupportService.CreateAsync(model, id) ?? throw new Exception($"--> error: Create Proposal Support Failed!");
        return StatusCode(StatusCodes.Status201Created, result);       
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _proposalSupportService.GetByProposalAsync(id));
    }

    [Route("/api/proposal-supports/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _proposalSupportService.GetByIdAsync(id);
        return Ok(result);
    }

    [Route("/api/proposal-supports/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _proposalSupportService.DeleteAsync(id);
        return NoContent();
    }


}