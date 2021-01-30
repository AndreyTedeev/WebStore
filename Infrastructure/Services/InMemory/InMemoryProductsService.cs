using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class InMemoryProductsService : IProductsService
    {

        private readonly List<Brand> _brands;
        private readonly List<Category> _productCategories;

        public InMemoryProductsService()
        {
            _brands = TestData.Brands;
            _productCategories = TestData.Categories;
        }

        public IEnumerable<Brand> GetBrands() => _brands;

        public IEnumerable<Category> GetCategories() => _productCategories;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IEnumerable<Product> result = TestData.Products;

            if (filter?.CategoryId is { } categoryId)
                result = result.Where(product => product.CategoryId == categoryId);

            if (filter?.BrandId is { } brandId)
                result = result.Where(product => product.BrandId == brandId);

            return result;
        }
    }
}
