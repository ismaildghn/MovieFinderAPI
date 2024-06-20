using DVDRentalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmCategory.GetCategoriesByFilm
{
    public class GetCategoriesByFilmQueryResponse
    {
        public List<string> Name { get; set; }
    }
}
