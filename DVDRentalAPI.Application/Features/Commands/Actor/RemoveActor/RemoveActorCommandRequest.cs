using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Actor.RemoveActor
{
    public class RemoveActorCommandRequest : IRequest<RemoveActorCommandResponse>
    {
        public string Id { get; set; }
    }
}
