using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.Film.GetAllFilm
{
    public class GetAllFilmQueryRequest : IRequest<GetAllFilmQueryResponse>
    {
    }
}
