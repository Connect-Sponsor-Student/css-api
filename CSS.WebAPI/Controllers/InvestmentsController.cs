using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.InvestmentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CSS.WebAPI.Controllers;
public class InvestmentsController : BaseController
{
    private readonly IInvestmentService _investmentService;
    public InvestmentsController(IInvestmentService investmentService)
    {
        _investmentService = investmentService;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> GetBySponsor()
    {
        var result = await _investmentService.GetBySponsorAsync();
        return Ok(result.AsQueryable());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InvestmentCreateModel model)
    {
        var result = await _investmentService.CreateAsync(model) ?? throw new Exception($"err: Create Failed!");
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _investmentService.DeleteAsync(id);
        return NoContent();
    }

    [Route("/api/proposals/{id}/investments")]
    [HttpGet]
    public async Task<IActionResult> GetByProposal(Guid id)
    {
        var result = await _investmentService.GetAllByProposalAsync(id);
        return Ok(result.AsQueryable());
    }
}