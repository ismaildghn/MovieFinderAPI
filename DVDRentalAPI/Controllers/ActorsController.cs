using DVDRentalAPI.Application.Features.Commands.Actor.CreateActor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateActorCommandRequest createActorCommandRequest)
        {
            CreateActorCommandResponse response = await _mediator.Send(createActorCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
