using PackingRaport.Domain.Models;
using PackingRaport.DTOs;
using System.Xml.Linq;

namespace PackingRaport.Mappers
{
    public static class RaportMapper
    {
        public static RaportDto RaportToDto(this Raport raport)
        {
            return new RaportDto
            {
                Day = raport.Day,
                StartProductionTime = raport.StartProductionTime,
                EndProductionTime = raport.EndProductionTime,
                Quantity = raport.Quantity,
                Comments = raport.Comments,
                User = raport.User,
                Product = raport.Product,
                Containers = raport.Containers
            };
        }
    }
}

