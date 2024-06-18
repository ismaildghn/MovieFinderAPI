using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmActor.GetActorsByFilm
{
    public class GetActorsByFilmQueryResponse
    {
        public List<string> ActorNameSurname { get; set; }
    }
}
