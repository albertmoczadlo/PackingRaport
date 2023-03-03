using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public IEnumerable<Raport> GetAllRaports()
        {
            var raports = _context.Raports
                .Include(x => x.User)
                .Include(p => p.Product)
                .Include(c => c.Containers)
                .ToList();

            return raports;
        }

        public Raport GetById(int id)
        {
            var raport = _context.Raports.Find(id);

            if (raport == null)
            {
                throw new ArgumentNullException("Nie znaleziono raportu o podanym identyfikatorze.", nameof(id));
            }

            return raport;
        }

        public void AddRaport(Raport raport)
        {
            _context.Raports.Add(raport);
            _context.SaveChanges();
        }

        public IEnumerable<Container> GetContainers()
        {
            var container = _context.Containers;

            return container;
        }
    }
}
