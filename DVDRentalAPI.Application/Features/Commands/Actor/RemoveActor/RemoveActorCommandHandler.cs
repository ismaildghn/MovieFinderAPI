using DVDRentalAPI.Application.Repositories;
using MediatR;
using System.Net.Http.Headers;
namespace DVDRentalAPI.Application.Features.Commands.Actor.RemoveActor
{
    public class RemoveActorCommandHandler : IRequestHandler<RemoveActorCommandRequest, RemoveActorCommandResponse>
    {
        readonly IActorWriteRepository _actorWriteRepository;


        public RemoveActorCommandHandler(IActorWriteRepository actorWriteRepository)
        {
            _actorWriteRepository = actorWriteRepository;
        }

        public async Task<RemoveActorCommandResponse> Handle(RemoveActorCommandRequest request, CancellationToken cancellationToken)
        {
            await _actorWriteRepository.RemoveAsync(request.Id);
            await _actorWriteRepository.SaveAsync();

            return new();
        }
    }
}
