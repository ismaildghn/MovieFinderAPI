using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmCategory.GetCategoriesByFilm
{
    public class GetCategoriesByFilmQueryHandler : IRequestHandler<GetCategoriesByFilmQueryRequest, GetCategoriesByFilmQueryResponse>
    {
        readonly IFilmCategoryService _filmCategoryService;

        public GetCategoriesByFilmQueryHandler(IFilmCategoryService filmCategoryService)
        {
            _filmCategoryService = filmCategoryService;
        }

        public async Task<GetCategoriesByFilmQueryResponse> Handle(GetCategoriesByFilmQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _filmCategoryService.GetCategoriesByFilmAsync(request.FilmId);
            var categoryName = categories.Select(c => c.Name).ToList();
            return new GetCategoriesByFilmQueryResponse { Name = categoryName };
        }
    }
}
