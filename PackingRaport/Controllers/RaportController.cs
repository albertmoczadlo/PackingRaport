
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using System.Security.Claims;
using AutoMapper;
using PackingRaport.Helpers;
using PackingRaport.Persistance.Context;
using PackingRaport.Services.Interfaces;
using PackingRaport.ViewModels;

namespace PackingRaport.Controllers
{
    public class RaportController : Controller
    {
        private readonly IRaportRepositories _raportRepositories;
        private readonly IUserRepository _userRepository;
        private readonly IRaportServices _raportServices;
        private readonly IMapper _mapper;

        PackingRaportHelpers _helpers = new PackingRaportHelpers();
        public RaportController(IRaportRepositories raportRepositories, IUserRepository userRepository,
            IRaportServices raportServices, RaportDbContext dbContext, IMapper mapper)
        {
            _raportRepositories = raportRepositories;
            _userRepository = userRepository;
            _raportServices = raportServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ViewResult Index(string? sortOrder, string searchString, DateTime? searchDate, TypeProduct? searchType)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var raports = _raportRepositories.GetAllRaports();

            if (!String.IsNullOrEmpty(searchString))
            {
                raports = raports.Where(s => s.User.Name.Contains(searchString)
                                             || s.User.Surname.Contains(searchString));
            }

            if (searchDate.HasValue)
            {
                raports = raports.Where(s => s.StartProductionTime.Date == searchDate.Value.Date);
            }

            if (searchType.HasValue)
            {
                raports = raports.Where(s => s.Product.ProductName == searchType.Value);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    raports = raports.OrderByDescending(s => s.StartProductionTime);
                    break;
                case "Date":
                    raports = raports.OrderBy(s => s.Containers.Type);
                    break;
                case "date_desc":
                    raports = raports.OrderByDescending(s => s.Product.ProductName);
                    break;
                default:
                    raports = raports.OrderBy(s => s.User.Surname);
                    break;
            }

            return View(raports.ToList());
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
        public IActionResult CreateConfirmed(Raport raport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            _raportRepositories.AddRaport(_raportServices.CreateRaport(raport, user));

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _raportRepositories.GetById(id);

            ViewBag.UserName = _raportServices.GetUser(id);
            ViewBag.ProductName = _raportServices.GetProduct(id);
            ViewBag.Container = _raportServices.GetContainers(id);

            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var raport = _raportRepositories.GetById(id);

            RaportViewModel raportViewModel = _mapper.Map<RaportViewModel>(raport);

            return View(raportViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var raport = _raportRepositories.GetById(id);

            if (raport == null)
            {
                return NotFound();
            }

            _raportRepositories.RemoveRaport(raport);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var result = _raportRepositories.GetById(id);

            ViewBag.UserName = _raportServices.GetUser(id);
            ViewBag.ProductName = _raportServices.GetProduct(id);
            ViewBag.Container = _raportServices.GetContainers(id);


            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(Raport raport, int id)
        {
            var existingRaport = _raportRepositories.GetById(id);

            existingRaport.Day = raport.Day;
            existingRaport.StartProductionTime = raport.StartProductionTime;
            existingRaport.EndProductionTime = raport.EndProductionTime;
            existingRaport.Quantity = raport.Quantity;
            existingRaport.Product = raport.Product;
            existingRaport.Containers = raport.Containers;
            existingRaport.Comments = raport.Comments;

            _raportRepositories.Update(existingRaport);

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditConfirmed(Raport raport, int id)
        //{
        //    //var result = _raportRepositories.GetById(raport.Id);

        //    ViewBag.UserName = _raportServices.GetUser(id);
        //    ViewBag.ProductName = _raportServices.GetProduct(id);
        //    ViewBag.Container = _raportServices.GetContainers(id);

        //    //_raportServices.UpdateRaport(result);

        //    _raportServices.UpdateRaport(raport);

        //    return RedirectToAction("Index");

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditConfirmed(int? id)
        //{

        //}
    }
}
