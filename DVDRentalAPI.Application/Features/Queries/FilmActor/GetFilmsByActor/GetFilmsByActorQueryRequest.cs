using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmActor.GetFilmsByActor
{
    public class GetFilmsByActorQueryRequest : IRequest<GetFilmsByActorQueryResponse>
    {
        public string ActorId { get; set; }
    }
}
