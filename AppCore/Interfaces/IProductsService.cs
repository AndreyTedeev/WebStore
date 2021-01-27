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
        IEnumerable<ProductCategory> GetCategories();

        IEnumerable<Brand> GetBrands();
    }
}
