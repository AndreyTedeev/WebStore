using WebStore.Interfaces;
using Microsoft.AspNetCore.Http;
using WebStore.Entities;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace WebStore.Services.InCookies
{
    public class InCookiesCartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;

        public InCookiesCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var user = httpContextAccessor.HttpContext.User;
            var userName = user.Identity.IsAuthenticated ? user.Identity.Name : "None";
            _cartName = $"WebStore.Cart-{userName}";
        }

        public void Add(int id)
        {
            var cart = CartInCookies;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
                cart.Items.Add(new CartItem { ProductId = id });
            else
                item.Quantity++;

            CartInCookies = cart;
        }

        public void Remove(int id)
        {
            var cart = CartInCookies;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
                return;

            cart.Items.Remove(item);

            CartInCookies = cart;
        }

        public void Decrement(int id)
        {
            var cart = CartInCookies;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
                return;

            if (item.Quantity > 1)
                item.Quantity--;
            else
                cart.Items.Remove(item);

            CartInCookies = cart;
        }

        public void Clear()
        {
            var cart = CartInCookies;
            cart.Items.Clear();
            CartInCookies = cart;
        }

        public Cart Cart => CartInCookies;

        private void ReplaceCookies(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(_cartName);
            cookies.Append(_cartName, cookie);
        }

        private Cart CartInCookies
        {
            get
            {
                var context = _httpContextAccessor.HttpContext;
                var cookie = context.Request.Cookies[_cartName];
                if (cookie is null)
                {
                    var cart = new Cart();
                    context.Response.Cookies.Append(_cartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }

                ReplaceCookies(context.Response.Cookies, cookie);
                return JsonConvert.DeserializeObject<Cart>(cookie);
            }
            set
            {
                var context = _httpContextAccessor.HttpContext;
                ReplaceCookies(context.Response.Cookies, JsonConvert.SerializeObject(value));
            }
        }

    }
}
