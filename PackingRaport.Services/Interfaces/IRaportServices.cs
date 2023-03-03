using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.Models;

namespace PackingRaport.Services.Interfaces
{
    public interface IRaportServices
    {
        Raport CreateRaport(Raport raport, User user);
        public Tuple<string, string, string> GetUserProductContainer(int id);
    }
}
