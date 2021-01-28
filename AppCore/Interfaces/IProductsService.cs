using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities;

namespace WebStore.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter filter = null);
    }
}
