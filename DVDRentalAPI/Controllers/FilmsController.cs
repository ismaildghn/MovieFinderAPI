using DVDRentalAPI.Application.Features.Commands.Film.CreateFilm;
using DVDRentalAPI.Application.Features.Commands.Film.RemoveFilm;
using DVDRentalAPI.Application.Features.Commands.Film.UpdateFilm;
using DVDRentalAPI.Application.Features.Queries.Film.GetAllFilm;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        readonly IMediator _mediator;

        public FilmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm(CreateFilmCommandRequest createFilmCommandRequest)
        {
            CreateFilmCommandResponse response = await _mediator.Send(createFilmCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveFilm([FromRoute]RemoveFilmComandRequest removeFilmComandRequest)
        {
            RemoveFilmComandResponse response = await _mediator.Send(removeFilmComandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilm(UpdateFilmCommandRequest updateFilmCommandRequest)
        {
            UpdateFilmCommandResponse response = await _mediator.Send(updateFilmCommandRequest);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilm([FromQuery]GetAllFilmQueryRequest getAllFilmQueryRequest)
        {
            GetAllFilmQueryResponse response = await _mediator.Send(getAllFilmQueryRequest);
            return Ok(response);
        }
    }
}
