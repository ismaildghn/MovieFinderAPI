﻿using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Domain.Entities;
using DVDRentalAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Repositories
{
    public class ActorReadRepository : ReadRepository<Actor>, IActorReadRepository
    {
        public ActorReadRepository(MovieFinderAPIDbContext context) : base(context)
        {
        }
    }
}
