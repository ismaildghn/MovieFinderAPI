using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Actor.CreateActor
{
    public class CreateActorCommandRequest : IRequest<CreateActorCommandResponse>
    {
        public string NameSurname { get; set; }
    }
}
