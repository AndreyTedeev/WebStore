using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductsService _productsService;

        public BrandsViewComponent(IProductsService productsService) => _productsService = productsService;

        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandViewModel> GetBrands()
        {
            return _productsService.GetBrands()
                .OrderBy(brand => brand.OrderNumber)
                .Select(brand => new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name
                });
        }
    }
}
