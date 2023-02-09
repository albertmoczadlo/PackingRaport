using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Persistance.Context;

namespace PackingRaport.Infrastructure.InterfaceRepository
{
    public class RaportRepositories : IRaportRepositories
    {
        private readonly RaportDbContext _context;

        public RaportRepositories(RaportDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Raport>> GetAllRaports()
        {
            var raports = await _context.Raports
                .Include(x => x.User)
                .Include(p => p.Products)
                .Include(c => c.Containers)
                .ThenInclude(t => t.Tanks)
                .ToListAsync();

            return raports;
        }
    }
}
