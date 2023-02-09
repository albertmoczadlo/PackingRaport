using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Persistance.Context;

namespace PackingRaport.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly RaportDbContext _context;

        public UserRepository(RaportDbContext context)
        {
            _context=context;
        }

        public User GetUserById(string id)
        {
            var user =  _context.Users.Find(id);

            if (user == null)
            {
                throw new ArgumentNullException("Nie znaleziono użytkownika o podanym identyfikatorze.", nameof(id));
            }

            return user;
        }
    }
}
