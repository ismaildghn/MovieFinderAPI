using DVDRentalAPI.Application.Features.Commands.FilmCategory.AddFilmCategory;
using DVDRentalAPI.Application.Features.Queries.FilmCategory.GetCategoriesByFilm;
using DVDRentalAPI.Application.Features.Queries.FilmCategory.GetFilmsByCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmCategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public FilmCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddFilmCategory(AddFilmCategoryCommandRequest addFilmCategoryCommandRequest)
        {
            AddFilmCategoryCommandResponse response = await _mediator.Send(addFilmCategoryCommandRequest);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoriesByFilm(GetCategoriesByFilmQueryRequest getCategoriesByFilmQueryRequest)
        {
            GetCategoriesByFilmQueryResponse response = await _mediator.Send(getCategoriesByFilmQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFilmsByCategory(GetFilmsByCategoryQueryRequest getFilmsByCategoryQueryRequest)
        {
            GetFilmsByCategoryQueryResponse response = await _mediator.Send(getFilmsByCategoryQueryRequest);
            return Ok(response);
        }

    }
}
