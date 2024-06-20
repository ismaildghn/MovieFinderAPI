using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.FilmCategory.AddFilmCategory
{
    public class AddFilmCategoryCommandRequest : IRequest<AddFilmCategoryCommandResponse>
    {
        public string FilmId { get; set; }
        public string CategoryId { get; set; }
    }
}
