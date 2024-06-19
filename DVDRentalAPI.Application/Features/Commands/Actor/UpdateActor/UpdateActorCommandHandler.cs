using DVDRentalAPI.Application.Repositories;
using MediatR;
using A = DVDRentalAPI.Domain.Entities;
namespace DVDRentalAPI.Application.Features.Commands.Actor.UpdateActor
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommandRequest, UpdateActorCommandResponse>
    {
        readonly IActorReadRepository _actorReadRepository;
        readonly IActorWriteRepository _actorWriteRepository;
        public async Task<UpdateActorCommandResponse> Handle(UpdateActorCommandRequest request, CancellationToken cancellationToken)
        {
            A.Actor actor = await _actorReadRepository.GetByIdAsync(request.Id);

            actor.NameSurname = request.NameSurname;
            actor.UpdatedDate = DateTime.UtcNow;
            await _actorWriteRepository.SaveAsync();

            return new();
        }
    }
}
