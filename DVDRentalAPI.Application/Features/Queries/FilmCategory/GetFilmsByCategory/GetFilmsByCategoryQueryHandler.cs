using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmCategory.GetFilmsByCategory
{
    public class GetFilmsByCategoryQueryHandler : IRequestHandler<GetFilmsByCategoryQueryRequest, GetFilmsByCategoryQueryResponse>
    {
        readonly IFilmCategoryService _filmCategoryService;

        public GetFilmsByCategoryQueryHandler(IFilmCategoryService filmCategoryService)
        {
            _filmCategoryService = filmCategoryService;
        }

        public async Task<GetFilmsByCategoryQueryResponse> Handle(GetFilmsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var films = await _filmCategoryService.GetFilmsByCategoryAsync(request.CategoryId);
            var filmName = films.Select(f => f.Title).ToList();
            return new GetFilmsByCategoryQueryResponse { Title = filmName };
        }
    }
}
