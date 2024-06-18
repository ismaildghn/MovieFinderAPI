using DVDRentalAPI.Application.Features.Commands.Language.CreateLanguage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        readonly IMediator _mediator;

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(CreateLanguageCommandRequest createLanguageCommandRequest)
        {
            CreateLanguageCommandResponse response = await _mediator.Send(createLanguageCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
