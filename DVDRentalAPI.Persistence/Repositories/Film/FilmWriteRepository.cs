using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Domain.Entities;
using DVDRentalAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Repositories
{
    public class FilmWriteRepository : WriteRepository<Film>, IFilmWriteRepository
    {
        public FilmWriteRepository(DVDRentalAPIDbContext context) : base(context)
        {
        }
    }
}
