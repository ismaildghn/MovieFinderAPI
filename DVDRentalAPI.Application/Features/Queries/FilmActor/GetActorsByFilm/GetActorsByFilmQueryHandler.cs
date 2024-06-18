using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmActor.GetActorsByFilm
{
    public class GetActorsByFilmQueryHandler : IRequestHandler<GetActorsByFilmQueryRequest, GetActorsByFilmQueryResponse>
    {
        readonly IFilmActorService _filmActorService;

        public GetActorsByFilmQueryHandler(IFilmActorService filmActorService)
        {
            _filmActorService = filmActorService;
        }

        public async Task<GetActorsByFilmQueryResponse> Handle(GetActorsByFilmQueryRequest request, CancellationToken cancellationToken)
        {
            var actors = await _filmActorService.GetActorsByFilmAsync(request.FilmId);

            var actorNames = actors.Select(a => a.NameSurname).ToList();

            return new GetActorsByFilmQueryResponse
            {
                ActorNameSurname = actorNames
            };
        }
    }
}
