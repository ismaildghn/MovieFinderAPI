using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Film.UpdateFilm
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommandRequest, UpdateFilmCommandResponse>
    {
        readonly IFilmReadRepository _filmReadRepository;
        readonly IFilmWriteRepository _filmWriteRepository;

        public UpdateFilmCommandHandler(IFilmReadRepository filmReadRepository, IFilmWriteRepository filmWriteRepository)
        {
            _filmReadRepository = filmReadRepository;
            _filmWriteRepository = filmWriteRepository;
        }

        public Task<UpdateFilmCommandResponse> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
