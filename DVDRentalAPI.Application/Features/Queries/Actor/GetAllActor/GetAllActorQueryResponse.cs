using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = DVDRentalAPI.Domain.Entities;

namespace DVDRentalAPI.Application.Features.Queries.Actor.GetAllActor
{
    public class GetAllActorQueryResponse
    {
        public List<string> Actors { get; set; }
    }
}
