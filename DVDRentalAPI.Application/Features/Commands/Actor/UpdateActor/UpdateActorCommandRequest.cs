using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Actor.UpdateActor
{
    public class UpdateActorCommandRequest : IRequest<UpdateActorCommandResponse>
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
    }
}
