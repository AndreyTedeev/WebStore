using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static IEnumerable<ProductViewModel> ToVieW(this IEnumerable<Product> source) =>
            source.Select(product => ToView(product));

        public static Product ToModel(this ProductViewModel source) => new Product
        {
            Id = source.Id,
            Name = source.Name,
            Price = source.Price,
            ImageUrl = source.ImageUrl,
            Brand = source.Brand
        };

    }
}
