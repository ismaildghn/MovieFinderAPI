using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Actor.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommandRequest, CreateActorCommandResponse>
    {
        readonly IActorWriteRepository _actorWriteRepository;

        public CreateActorCommandHandler(IActorWriteRepository actorWriteRepository)
        {
            _actorWriteRepository = actorWriteRepository;
        }

        public async Task<CreateActorCommandResponse> Handle(CreateActorCommandRequest request, CancellationToken cancellationToken)
        {
            await _actorWriteRepository.AddAsync(new()
            {
                NameSurname = request.NameSurname,
                CreatedDate = DateTime.UtcNow,
            });
            await _actorWriteRepository.SaveAsync();
            return new();
        }
    }
}
