using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmActor.GetFilmsByActor
{
    public class GetFilmsByActorQueryHandler : IRequestHandler<GetFilmsByActorQueryRequest, GetFilmsByActorQueryResponse>
    {
        readonly IFilmActorService _filmActorService;

        public GetFilmsByActorQueryHandler(IFilmActorService filmActorService)
        {
            _filmActorService = filmActorService;
        }

        public async Task<GetFilmsByActorQueryResponse> Handle(GetFilmsByActorQueryRequest request, CancellationToken cancellationToken)
        {
            var films = await _filmActorService.GetFilmsByActorAsync(request.ActorId);

            var filmDetail = films.Select(f => f.Title).ToList();

            return new GetFilmsByActorQueryResponse
            {
                Title = filmDetail
            };

        }
    }
}
