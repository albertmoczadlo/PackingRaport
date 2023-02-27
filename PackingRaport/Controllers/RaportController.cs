using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Infrastructure.InterfaceRepository;
using System.Security.Claims;
using AutoMapper;
using PackingRaport.Domain.ViewModels;

using PackingRaport.Persistance.Context;

namespace PackingRaport.Controllers
{
    public class RaportController : Controller
    {
        private readonly IRaportRepositories _raportRepositories;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly RaportDbContext _dbContext;
        public RaportController(IRaportRepositories raportRepositories, IUserRepository userRepository, IProductRepository productRepository,
            IMapper mapper, RaportDbContext dbContext)
        {
            _raportRepositories = raportRepositories;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var list = _raportRepositories.GetAllRaports();



            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var listUsers = _userRepository.GetAllUsers();

            List<SelectListItem> userListName = new List<SelectListItem>();

            User user = _userRepository.GetUserById(id);

            userListName.Add(new SelectListItem(user.Name + " " + user.Surname, user.Id));

            ViewBag.UserListName = userListName;

            ViewBag.ProductList = Enum.GetValues(typeof(TypeProduct)).Cast<TypeProduct>().Select(p => new SelectListItem
            {
                Text = p.ToString(),
                Value = p.ToString()
            }).ToList();

            ViewBag.ContainerList = Enum.GetValues(typeof(TypeContainer)).Cast<TypeContainer>().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = ((int)c).ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(RaportViewModel raport)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

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

            _raportRepositories.AddRaport(newRaport);

            return RedirectToAction("Index");

        }

        //public async Task<IActionResult> CreateConfirmed(RaportViewModel raport, int productIndex)
        //{
        //    string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var user = _userRepository.GetUserById(id);

        //    ////maper

        //    //foreach (var product in raport.Products)
        //    //{
        //    //    tRaport.Products.Add(_productRepository.GetById(product));
        //    //}


        //    _raportRepositories.AddRaport(tRaport);

        //    return RedirectToAction("Index");
        //}



    }
}
