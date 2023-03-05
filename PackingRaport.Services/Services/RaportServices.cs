using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Services.Interfaces;

namespace PackingRaport.Services.Services
{
    public class RaportServices:IRaportServices
    {
        private readonly IRaportRepositories _raportRepositories;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public RaportServices(IRaportRepositories raportRepositories, IUserRepository userRepository,
            IProductRepository productRepository)
        {
                _raportRepositories= raportRepositories;
                _userRepository= userRepository;
                _productRepository= productRepository;
        }

        public Raport CreateRaport(Raport raport, User user)
        {
            var product = new Product
            {
                ProductName = raport.Product.ProductName
            };

            Raport newRaport = new Raport
            {
                Day = raport.Day,
                StartProductionTime = raport.StartProductionTime,
                EndProductionTime = raport.EndProductionTime,
                UserId = user.Id,
                Product = product,
                Containers = new Container
                {
                    Type = raport.Containers.Type
                },
                Quantity = raport.Quantity
            };

            return newRaport;
        }

        //public Tuple<string, string,string> GetUserProductContainer(int id)
        //{
        //    var result = _raportRepositories.GetById(id);

        //    var user = _userRepository.GetAllUsers()
        //        .Where(x => x.Id == result.UserId).Select(x => $"{x.Name} {x.Surname}").FirstOrDefault();

        //    var product = _productRepository.GetProducts()
        //        .Where(x => x.RaportId == result.Id).Select(x => $"{x.ProductName.ToString()}").FirstOrDefault();

        //    var containers = _raportRepositories.GetContainers()
        //        .Where(x=>x.RaportId==id)
        //        .Select(x=>$"{x.Type.ToString()}").FirstOrDefault();

        //    return Tuple.Create(user, product,containers);
        //}

        public string GetUser(int id)
        {
            var result = _raportRepositories.GetById(id);
            var user = _userRepository.GetAllUsers()
                .Where(x => x.Id == result.UserId)
                .Select(x => $"{x.Name} {x.Surname}")
                .FirstOrDefault();
            return user;
        }

        public string GetProduct(int id)
        {
            var result = _raportRepositories.GetById(id);
            var product = _productRepository.GetProducts()
                .Where(x => x.RaportId == result.Id)
                .Select(x => $"{x.ProductName.ToString()}")
                .FirstOrDefault();
            return product;
        }

        public string GetContainers(int id)
        {
            var containers = _raportRepositories.GetContainers()
                .Where(x => x.RaportId == id)
                .Select(x => $"{x.Type.ToString()}")
                .FirstOrDefault();
            return containers;
        }

    }
}
