using DVDRentalAPI.Application.Features.Queries.Actor.GetAllActor;
using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.Actor.GetAllActor
{
    public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQueryRequest, GetAllActorQueryResponse>
    {
        readonly IActorReadRepository _actorReadRepository;

        public GetAllActorQueryHandler(IActorReadRepository actorReadRepository)
        {
            _actorReadRepository = actorReadRepository;
        }

        public async Task<GetAllActorQueryResponse> Handle(GetAllActorQueryRequest request, CancellationToken cancellationToken)
        {
            var actors = _actorReadRepository.GetAll()
                .Select(a =>  a.NameSurname)
                .ToList();

            return new GetAllActorQueryResponse { Actors = actors };

        }

    }
}

