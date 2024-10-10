using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Domain.Entities.Common;
using DVDRentalAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly MovieFinderAPIDbContext _context;

        public ReadRepository(MovieFinderAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
