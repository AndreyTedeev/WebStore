using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{

    public class CatalogController : Controller
    {

        private readonly IProductsService _productsService;

        public CatalogController(IProductsService productsService) => _productsService = productsService;

        public IActionResult Index(int? categoryId, int? brandId)
        {
            ProductFilter filter = new() { CategoryId = categoryId, BrandId = brandId };

            var products = _productsService.GetProducts(filter);

            return View(new CatalogViewModel
            {
                CategoryId = categoryId,
                BrandId = brandId,
                Products = products.OrderBy(p => p.OrderNumber).ToVieW()
            });
        }

        public IActionResult Details(int id) =>
            View(_productsService.GetProduct(id).ToView());

    }
}
