using DVDRentalAPI.Application.Abstractions.Services;
using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Application.ViewModels;
using DVDRentalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Services
{
    public class FilmActorService : IFilmActorService
    {
        readonly IFilmReadRepository _filmReadRepository;
        readonly IFilmWriteRepository _filmWriteRepository;
        readonly IActorReadRepository _actorReadRepository;
        readonly IActorWriteRepository _actorWriteRepository;
        readonly IFilmActorReadRepository _filmActorReadRepository;
        readonly IFilmActorWriteRepository _filmActorWriteRepository;

        public FilmActorService(IFilmReadRepository filmReadRepository, IFilmWriteRepository filmWriteRepository, IActorReadRepository actorReadRepository, IActorWriteRepository actorWriteRepository, IFilmActorReadRepository filmActorReadRepository, IFilmActorWriteRepository filmActorWriteRepository)
        {
            _filmReadRepository = filmReadRepository;
            _filmWriteRepository = filmWriteRepository;
            _actorReadRepository = actorReadRepository;
            _actorWriteRepository = actorWriteRepository;
            _filmActorReadRepository = filmActorReadRepository;
            _filmActorWriteRepository = filmActorWriteRepository;
        }

        public async Task AddFilmActorAsync(VM_Create_FilmActor film)
        {
            Film _film = await _filmReadRepository
                .Table
                .Where(f => f.Id == Guid.Parse(film.FilmId))
                .FirstOrDefaultAsync();

            Actor _actor = await _actorReadRepository
                .Table
                .Where(a => a.Id == Guid.Parse(film.ActorId))
                .FirstOrDefaultAsync();

            if (_film != null && _actor != null)
            {
                var filmActor = new FilmActor
                {
                    ActorId = _actor.Id,
                    Actor = _actor,
                    FilmId = _film.Id,
                    Film = _film
                };
                await _filmActorWriteRepository.AddAsync(filmActor);
                await _filmActorWriteRepository.SaveAsync();
            }
            else
            {
                throw new Exception("Actor or film not found");
            }
        }

        public async Task<List<Actor>> GetActorsByFilmAsync(string filmId)
        {

            var actors = await _filmActorReadRepository
                  .Table
                  .Where(fa => fa.FilmId == Guid.Parse(filmId))
                  .Select(fa => fa.Actor)
                  .ToListAsync();

            return actors;

        }

        public async Task<List<Film>> GetFilmsByActorAsync(string actorId)
        {
            var films = await _filmActorReadRepository
                .Table
                .Where(fa => fa.ActorId == Guid.Parse(actorId))
                .Select(a => a.Film)
                .ToListAsync();

            return films;
        }
    }
}
