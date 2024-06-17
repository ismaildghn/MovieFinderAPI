using DVDRentalAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }
        public float Rating { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
        public ICollection<FilmActor> FilmActor { get; set; }

    }
}
