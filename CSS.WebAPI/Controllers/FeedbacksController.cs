using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.FeedbackModels;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CSS.WebAPI.Controllers;
public class FeedbacksController : BaseController
{
    private readonly IFeedbackService _feedbackService;
    public FeedbacksController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok((await _feedbackService.GetAllAsync()).AsQueryable());
    }

    [Authorize(Roles = nameof(RoleEnum.Admin))]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]FeedbackCreateModel model) 
    {
        var result = await _feedbackService.CreateAsync(model);
        if(result is not null)
        {
            return StatusCode(StatusCodes.Status201Created, result);
        } else throw new Exception($"--> Error: Create Feedback Failed!");
    }

    [EnableQuery]
    [Route("/api/proposals/{id}/feedbacks")]
    [HttpGet]

    public async Task<IActionResult> GetByProposal(Guid id)
    {
        var result = await _feedbackService.GetByProposalAsync(id);
        return Ok(result.AsQueryable());
    }
    
}