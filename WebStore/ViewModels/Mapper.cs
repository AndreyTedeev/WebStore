using System.Collections.Generic;
using System.Linq;
using WebStore.Entities;

namespace WebStore.ViewModels
{
    public static class Mapper
    {
        public static ProductViewModel ToView(this Product source) => new ProductViewModel
        {
            Id = source.Id,
            Name = source.Name,
            Price = source.Price,
            ImageUrl = source.ImageUrl,
            Brand = source.Brand
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> source) =>
            source.Select(product => ToView(product));

        public static Product ToModel(this ProductViewModel source) => new Product
        {
            Id = source.Id,
            Name = source.Name,
            Price = source.Price,
            ImageUrl = source.ImageUrl,
            Brand = source.Brand
        };

        public static CartViewModel ToView(this Cart source, IEnumerable<Product> products)
        {
            var dictionary = products.ToView().ToDictionary(product => product.Id);

            return new CartViewModel
            {
                Items = source.Items
                    .Where(item => dictionary.ContainsKey(item.ProductId))
                    .Select(item => (dictionary[item.ProductId], item.Quantity))
            };
        }

        public static IEnumerable<UserOrderViewModel> ToView(this IEnumerable<Order> source) =>
            source.Select(order => ToView(order));

        public static UserOrderViewModel ToView(this Order source)
        {
            return new UserOrderViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Phone = source.Phone,
                Address = source.Address,
                Total = source.Items.Sum(item => item.Price * item.Quantity)
            };
        }
    }
}
