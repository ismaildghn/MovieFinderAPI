using DVDRentalAPI.Application.ViewModels;
using DVDRentalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Abstractions.Services
{
    public interface IFilmActorService
    {
        public Task AddFilmActorAsync(VM_Create_FilmActor film);
        Task<List<Film>> GetFilmsByActorAsync(string actorId);
        Task<List<Actor>> GetActorsByFilmAsync(string filmId);
    }
}
