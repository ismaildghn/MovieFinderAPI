using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Film.RemoveFilm
{
    public class RemoveFilmComandHandler : IRequestHandler<RemoveFilmComandRequest, RemoveFilmComandResponse>
    {
        readonly IFilmWriteRepository _filmWriteRepository;

        public RemoveFilmComandHandler(IFilmWriteRepository filmWriteRepository)
        {
            _filmWriteRepository = filmWriteRepository;
        }

        public async Task<RemoveFilmComandResponse> Handle(RemoveFilmComandRequest request, CancellationToken cancellationToken)
        {
            await _filmWriteRepository.RemoveAsync(request.Id);
            await _filmWriteRepository.SaveAsync();
            return new();
        }
    }
}
