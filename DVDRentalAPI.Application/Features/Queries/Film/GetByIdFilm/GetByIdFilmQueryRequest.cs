using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Queries.Film.GetByIdFilm
{
    public class GetByIdFilmQueryRequest : IRequest<GetByIdFilmQueryResponse>
    {
        public string Id { get; set; }
    }
}
