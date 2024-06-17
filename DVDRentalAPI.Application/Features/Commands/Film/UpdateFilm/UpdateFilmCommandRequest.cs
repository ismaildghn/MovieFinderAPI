using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Film.UpdateFilm
{
    public class UpdateFilmCommandRequest : IRequest<UpdateFilmCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }
        public float Rating { get; set; }
    }
}
