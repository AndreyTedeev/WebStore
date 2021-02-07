using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Entities;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class SqlServerProductsService : IProductsService
    {
        private readonly Db _db;

        public SqlServerProductsService(Db db)
        {
            _db = db;
        }

        public IEnumerable<Brand> GetBrands() => _db.Brands.Include((b) => b.Products).ToList();

        public IEnumerable<Category> GetCategories() => _db.Categories.Include((c) => c.Products).ToList();

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IEnumerable<Product> result = _db.Products;

            if (filter?.CategoryId is { } categoryId)
                result = result.Where(product => product.CategoryId == categoryId);

            if (filter?.BrandId is { } brandId)
                result = result.Where(product => product.BrandId == brandId);

            return result;
        }

        public Product GetProduct(int id) => _db.Products
            .Include(product => product.Brand)
            .Include(product => product.Category)
            .Single(product => product.Id == id);
    }
}
