using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.FilmCategory.GetFilmsByCategory
{
    public class GetFilmsByCategoryQueryRequest : IRequest<GetFilmsByCategoryQueryResponse>
    {
        public string CategoryId { get; set; }
    }
}
