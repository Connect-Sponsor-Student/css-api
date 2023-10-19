using CSS.Application.Services.Interfaces;
using CSS.Application.ViewModels.InboxModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSS.WebAPI.Controllers
{
    public class InboxsController:BaseController
    {
        private readonly IInboxService _service;

        public InboxsController(IInboxService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(InboxCreateModel model)
        {
            var result = await _service.CreateInbox(model);
            return StatusCode(StatusCodes.Status201Created,result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetInboxes();
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{id}/messages")]
        public async Task<IActionResult> GetAllMessageByInboxId(Guid id)
        {
            var result = await _service.GetAllMessageByInboxId(id);
            return Ok(result);
        }
    }
}
