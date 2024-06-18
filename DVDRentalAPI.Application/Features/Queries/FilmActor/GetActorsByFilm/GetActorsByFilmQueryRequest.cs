using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmActor.GetActorsByFilm
{
    public class GetActorsByFilmQueryRequest : IRequest<GetActorsByFilmQueryResponse>
    {
        public string FilmId { get; set; }
    }
}
