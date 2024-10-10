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
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(MovieFinderAPIDbContext context) : base(context)
        {
        }
    }
}
