using DVDRentalAPI.Application.Features.Commands.Film.CreateFilm;
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
    }
}
