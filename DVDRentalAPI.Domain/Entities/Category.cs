using DVDRentalAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
