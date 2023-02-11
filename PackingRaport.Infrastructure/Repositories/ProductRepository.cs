using PackingRaport.Domain.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.Models;
using PackingRaport.Persistance.Context;

namespace PackingRaport.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly RaportDbContext _context;

        public ProductRepository(RaportDbContext context)
        {
                _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            return products;
        }
    }
}
