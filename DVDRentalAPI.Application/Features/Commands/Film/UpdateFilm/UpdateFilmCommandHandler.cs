using DVDRentalAPI.Application.Repositories;
using MediatR;
using F = DVDRentalAPI.Domain.Entities;
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

        public async Task<UpdateFilmCommandResponse> Handle(UpdateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            F.Film film = await _filmReadRepository.GetByIdAsync(request.Id);

            film.Title = request.Title;
            film.Description = request.Description;
            film.ReleaseYear = request.ReleaseYear;
            film.Length = request.Length;
            film.Rating = request.Rating;
            film.UpdatedDate = DateTime.UtcNow;
            await _filmWriteRepository.SaveAsync();

            return new();
                      
        }
    }
}
