using Microsoft.AspNetCore.Mvc;
using PackingRaport.Domain.InterfaceRepository;

namespace PackingRaport.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
                _productRepository= productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }
    }
}
