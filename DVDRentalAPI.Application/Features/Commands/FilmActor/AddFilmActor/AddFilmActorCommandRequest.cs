using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.FilmActor.AddFilmActor
{
    public class AddFilmActorCommandRequest : IRequest<AddFilmActorCommandResponse>
    {
        public string FilmId { get; set; }
        public string ActorId { get; set; }
    }
}
