using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;
using System.Security.Claims;

namespace PackingRaport.Controllers
{
    public class RaportController : Controller
    {
        private readonly IRaportRepositories _raportRepositories;
        private readonly IUserRepository _userRepository;

        public RaportController(IRaportRepositories raportRepositories, IUserRepository userRepository)
        {
                _raportRepositories = raportRepositories;
                _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _raportRepositories.GetAllRaports();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed(Raport raport)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var usId = _userRepository.GetUserById(id);

            raport.UserId = usId.Id;

            _raportRepositories.AddRaport(raport);

            return RedirectToAction("Index");
        }
    }
}
