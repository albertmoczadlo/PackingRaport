using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using PackingRaport.Infrastructure.InterfaceRepository;
using System.Security.Claims;
using PackingRaport.Domain.ViewModels;

namespace PackingRaport.Controllers
{
    public class RaportController : Controller
    {
        private readonly IRaportRepositories _raportRepositories;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public RaportController(IRaportRepositories raportRepositories, IUserRepository userRepository, IProductRepository productRepository)
        {
                _raportRepositories = raportRepositories;
                _userRepository = userRepository;
                _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _raportRepositories.GetAllRaports();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var listUsers = _userRepository.GetAllUsers();

            List<SelectListItem> userListName = new List<SelectListItem>();

            User user = _userRepository.GetUserById(id);
          
            userListName.Add(new SelectListItem(user.Name + " " + user.Surname, user.Id ));

            ViewBag.UserListName = userListName;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed(RaportViewModel raport, int productIndex)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userRepository.GetUserById(id);

            //raport.User = user;

            Raport tRaport = new Raport();

            tRaport.User = user;

            foreach (var product in raport.Products)
            {
                tRaport.Products.Add(_productRepository.GetById(product));
            }

            tRaport.EndProductionTime = raport.EndProductionTime;
            
            
            _raportRepositories.AddRaport(tRaport);

            return RedirectToAction("Index");
        }



    }
}
