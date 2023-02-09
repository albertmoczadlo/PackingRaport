using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackingRaport.Domain.InterfaceRepository;
using PackingRaport.Domain.Models;

namespace PackingRaport.Controllers
{
    public class RaportController : Controller
    {
        private readonly IRaportRepositories _raportRepositories;

        public RaportController(IRaportRepositories raportRepositories)
        {
                _raportRepositories = raportRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _raportRepositories.GetAllRaports();

            return View(list);
        }
    }
}
