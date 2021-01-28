using System.Collections.Generic;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class ProductsService : IProductsService
    {

        private readonly List<Brand> _brands;
        private readonly List<ProductCategory> _productCategories;

        public ProductsService()
        {
            _brands = TestData.Brands;
            _productCategories = TestData.ProductCategories;
        }

        public IEnumerable<Brand> GetBrands() => _brands;

        public IEnumerable<ProductCategory> GetCategories() => _productCategories;
    }
}
