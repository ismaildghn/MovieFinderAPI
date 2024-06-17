using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDRentalAPI.Domain.Entities.Common;

namespace DVDRentalAPI.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Film> Film { get; set; }
    }
}
