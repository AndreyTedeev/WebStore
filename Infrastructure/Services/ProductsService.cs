using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services
{
    class ProductsService : IProductsService
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
