using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Film.RemoveFilm
{
    public class RemoveFilmComandRequest : IRequest<RemoveFilmComandResponse>
    {
        public string Id { get; set; }
    }
}
