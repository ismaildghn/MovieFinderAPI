using DVDRentalAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.FilmActor.AddFilmActor
{
    public class AddFilmActorCommandHandler : IRequestHandler<AddFilmActorCommandRequest, AddFilmActorCommandResponse>
    {
        readonly IFilmActorService _filmActorService;

        public AddFilmActorCommandHandler(IFilmActorService filmActorService)
        {
            _filmActorService = filmActorService;
        }

        public async Task<AddFilmActorCommandResponse> Handle(AddFilmActorCommandRequest request, CancellationToken cancellationToken)
        {
            await _filmActorService.AddFilmActorAsync(new()
            {
                ActorId = request.ActorId,
                FilmId = request.FilmId,             
            });
            return new();
        }
    }
}
