using DVDRentalAPI.Application.DTOs.Actor;
using DVDRentalAPI.Application.DTOs.Film;
using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.Film.GetAllFilm
{
    public class GetAllFilmQueryHandler : IRequestHandler<GetAllFilmQueryRequest, GetAllFilmQueryResponse>
    {
        readonly IFilmReadRepository _filmReadRepository;

        public GetAllFilmQueryHandler(IFilmReadRepository filmReadRepository)
        {
            _filmReadRepository = filmReadRepository;
        }

        public async Task<GetAllFilmQueryResponse> Handle(GetAllFilmQueryRequest request, CancellationToken cancellationToken)
        {
            var films = _filmReadRepository.GetAll()
                .Include(f => f.FilmActor)
                .ThenInclude(fa => fa.Actor)
                .Select(f => new ListFilm
                {
                    Id = f.Id,
                    Title = f.Title,
                    Description = f.Description,
                    Language = f.Language,
                    Length = f.Length,
                    Rating = f.Rating,
                    ReleaseYear = f.ReleaseYear,
                    Actors = f.FilmActor.Select(fa => new ListActor
                    {
                        NameSurname = fa.Actor.NameSurname
                    }).ToList()
                }).ToList();
            return new GetAllFilmQueryResponse
            {
                Films = films
            };
        }
    }
}

