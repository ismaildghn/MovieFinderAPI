using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.FilmCategory.AddFilmCategory
{
    public class AddFilmCategoryCommandHandler : IRequestHandler<AddFilmCategoryCommandRequest, AddFilmCategoryCommandResponse>
    {
        IFilmCategoryService _filmCategoryService;

        public AddFilmCategoryCommandHandler(IFilmCategoryService filmCategoryService)
        {
            _filmCategoryService = filmCategoryService;
        }

        public async Task<AddFilmCategoryCommandResponse> Handle(AddFilmCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _filmCategoryService.AddFilmCategoryAsync(new()
            {
                CategoryId = request.CategoryId,
                FilmId = request.FilmId,
            });
            return new();
        }
    }
}
