using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using WebStore.Entities;
using WebStore.Entities.Identity;
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
            var model = new CartOrderViewModel
            {
                Cart = GetCartViewModel()
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

        public async Task<IActionResult> CheckOut(
            OrderViewModel orderModel,
            [FromServices] IOrdersService ordersService,
            [FromServices] UserManager<User> userManager)
        {
            var cartModel = GetCartViewModel();

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), new CartOrderViewModel
                {
                    Cart = cartModel,
                    Order = orderModel
                });

            }
            var userName = User.Identity?.Name;
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
                throw new InvalidOperationException($"User {userName} is not found.");

            var order = CreateOrder(user, cartModel, orderModel);
            await ordersService.Add(order);

            _cartService.Clear();
            return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        private Order CreateOrder(User user, CartViewModel cartModel, OrderViewModel orderModel)
        {
            var order = new Order
            {
                Name = orderModel.Name,
                Phone = orderModel.Phone,
                Address = orderModel.Address,
                User = user
            };

            var cart_products = _productsService.GetProducts(new ProductFilter
            {
                Ids = cartModel.Items.Select(x => x.Product.Id).ToArray()
            });

            order.Items = cartModel.Items.Join(
                cart_products,
                cart_item => cart_item.Product.Id,
                product => product.Id,
                (cart_item, product) => new OrderItem
                {
                    Order = order,
                    Product = product,
                    Quantity = cart_item.Quantity,
                    Price = product.Price
                }).ToArray();

            return order;
        }

        private CartViewModel GetCartViewModel()
        {
            var cart = _cartService.Cart;

            var products = _productsService.GetProducts(new ProductFilter
            {
                Ids = cart.Items.Select(item => item.ProductId).ToArray()
            });

            return cart.ToView(products);
        }

    }
}
