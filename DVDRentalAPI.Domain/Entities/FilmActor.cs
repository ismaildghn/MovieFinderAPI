using DVDRentalAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Domain.Entities
{
    public class FilmActor : BaseEntity
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }
        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
