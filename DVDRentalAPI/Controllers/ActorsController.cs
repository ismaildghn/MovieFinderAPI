using DVDRentalAPI.Application.Features.Commands.Actor.CreateActor;
using DVDRentalAPI.Application.Features.Commands.Actor.UpdateActor;
using DVDRentalAPI.Application.Features.Queries.Actor.GetAllActor;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateActor(CreateActorCommandRequest createActorCommandRequest)
        {
            CreateActorCommandResponse response = await _mediator.Send(createActorCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveActor([FromRoute]CreateActorCommandRequest createActorCommandRequest)
        {
            CreateActorCommandResponse response = await _mediator.Send(createActorCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor(UpdateActorCommandRequest updateActorCommandRequest)
        {
            UpdateActorCommandResponse response = await _mediator.Send(updateActorCommandRequest);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActor([FromQuery] GetAllActorQueryRequest getAllActorQueryRequest)
        {
            GetAllActorQueryResponse response = await _mediator.Send(getAllActorQueryRequest);
            return Ok(response);
        }

    }
}
