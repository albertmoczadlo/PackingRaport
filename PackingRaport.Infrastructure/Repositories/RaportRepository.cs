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
    public class RaportRepository : IRaportRepositories
    {
        private readonly RaportDbContext _context;

        public RaportRepository(RaportDbContext context)
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

        public async Task<Raport> GetById(int id)
        {
            var raport =await _context.Raports.FindAsync(id);

            if (raport == null)
            {
                throw new ArgumentNullException("Nie znaleziono raportu o podanym identyfikatorze.", nameof(id));
            }

            return raport;
        }

        public async Task AddRaport(Raport raport)
        {
            await _context.Raports.AddAsync(raport);
            await _context.SaveChangesAsync();
        }


    }
}
