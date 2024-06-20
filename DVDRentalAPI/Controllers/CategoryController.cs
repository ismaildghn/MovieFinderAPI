using DVDRentalAPI.Application.Features.Commands.Actor.CreateActor;
using DVDRentalAPI.Application.Features.Commands.Actor.RemoveActor;
using DVDRentalAPI.Application.Features.Commands.Actor.UpdateActor;
using DVDRentalAPI.Application.Features.Commands.Category.CreateCategory;
using DVDRentalAPI.Application.Features.Commands.Category.RemoveCategory;
using DVDRentalAPI.Application.Features.Commands.Category.UpdateCategory;
using DVDRentalAPI.Application.Features.Queries.Actor.GetAllActor;
using DVDRentalAPI.Application.Features.Queries.Category.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCategory([FromRoute]RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(removeCategoryCommandRequest);
            return Ok();
        }
    }
}
