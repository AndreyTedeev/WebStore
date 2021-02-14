using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using WebStore.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{

    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductsService _productsService;

        public CartController(ICartService cartService, IProductsService productsService)
        {
            _cartService = cartService;
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.Cart;

            var products = _productsService.GetProducts(new ProductFilter
            {
                Ids = cart.Items.Select(item => item.ProductId).ToArray()
            });

            var dictionary = products.ToVieW().ToDictionary(product => product.Id);

            var model = new CartViewModel
            {
                Items = cart.Items
                    .Where(item => dictionary.ContainsKey(item.ProductId))
                    .Select(item => (dictionary[item.ProductId], item.Quantity))
            };

            return View(model);
        }

        public IActionResult Add(int id)
        {
            _cartService.Add(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Decrement(int id)
        {
            _cartService.Decrement(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _cartService.Clear();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CheckOut() => View();

    }
}
