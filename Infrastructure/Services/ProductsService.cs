using System.Collections.Generic;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class ProductsService : IProductsService
    {

        private readonly List<Brand> _brands;
        private readonly List<Category> _productCategories;

        public ProductsService()
        {
            _brands = TestData.Brands;
            _productCategories = TestData.Categories;
        }

        public IEnumerable<Brand> GetBrands() => _brands;

        public IEnumerable<Category> GetCategories() => _productCategories;
    }
}
