using DVDRentalAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string NameSurname { get; set; }
        public ICollection<FilmActor> FilmActor { get; set; }
    }
}
