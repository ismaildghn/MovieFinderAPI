using DVDRentalAPI.Application.Features.Commands.FilmActor.AddFilmActor;
using DVDRentalAPI.Application.Features.Queries.FilmActor.GetActorsByFilm;
using DVDRentalAPI.Application.Features.Queries.FilmActor.GetFilmsByActor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmActorController : ControllerBase
    {
        readonly IMediator _mediator;

        public FilmActorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddFilmActor(AddFilmActorCommandRequest addFilmActorCommandRequest)
        {
            AddFilmActorCommandResponse response = await _mediator.Send(addFilmActorCommandRequest);
            return Ok(response);
        }

        [HttpGet("actorsByFilm")]
        public async Task<IActionResult> GetActorsByFilm(GetActorsByFilmQueryRequest getActorsByFilmQueryRequest)
        {
            GetActorsByFilmQueryResponse response = await _mediator.Send(getActorsByFilmQueryRequest);
            return Ok(response);
        }

        [HttpGet("filmsByActor")]
        public async Task<IActionResult> GetFilmsByActor(GetFilmsByActorQueryRequest getFilmsByActorQueryRequest)
        {
            GetFilmsByActorQueryResponse response = await _mediator.Send(getFilmsByActorQueryRequest);
            return Ok(response);
        }
    }
}
