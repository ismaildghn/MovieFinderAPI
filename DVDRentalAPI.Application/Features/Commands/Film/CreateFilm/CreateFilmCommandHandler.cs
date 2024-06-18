using DVDRentalAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Film.CreateFilm
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, CreateFilmCommandResponse>
    {
        readonly IFilmWriteRepository _filmWriteRepository;

        public CreateFilmCommandHandler(IFilmWriteRepository filmWriteRepository)
        {
            _filmWriteRepository = filmWriteRepository;
        }

        public async Task<CreateFilmCommandResponse> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            await _filmWriteRepository.AddAsync(new()
            {
                Title = request.Title,
                Description = request.Description,
                ReleaseYear = request.ReleaseYear,
                Length = request.Length,
                Rating = request.Rating,      
                LanguageId = request.LanguageId,
                CreatedDate = DateTime.UtcNow,
            });
            await _filmWriteRepository.SaveAsync();
            return new();

        }
    }
}
