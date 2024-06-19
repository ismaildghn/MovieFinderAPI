using DVDRentalAPI.Application.DTOs.Film;
using DVDRentalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = DVDRentalAPI.Domain.Entities;

namespace DVDRentalAPI.Application.Features.Queries.Film.GetAllFilm
{
    public class GetAllFilmQueryResponse
    {
        public List<ListFilm> Films { get; set; }
    }
}                
