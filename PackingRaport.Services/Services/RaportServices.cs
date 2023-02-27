using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.Models;
using PackingRaport.Services.Interfaces;

namespace PackingRaport.Services.Services
{
    public class RaportServices:IRaportServices
    {
        public Raport CreateRaport(Raport raport, User user)
        {
            var product = new Product
            {
                ProductName = raport.Product.ProductName
            };

            Raport newRaport = new Raport
            {
                StartProductionTime = raport.StartProductionTime,
                EndProductionTime = raport.EndProductionTime,
                UserId = user.Id,
                Product = product,
                Containers = new Container
                {
                    Type = raport.Containers.Type
                }
            };

            return newRaport;
        }
    }
}
