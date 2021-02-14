using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Entities;
using WebStore.Entities.Identity;
using WebStore.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            this._productsService = productsService;
        }

        public IActionResult Index()
        {
            return View(_productsService.GetProducts());
        }

        public IActionResult Edit(int id)
        {
            return _productsService.GetProduct(id) switch
            {
                null => NotFound(),
                Product product => View(product)
            };
        }

        public IActionResult Delete(int id)
        {
            return _productsService.GetProduct(id) switch
            {
                null => NotFound(),
                Product product => View(product)
            };
        }
    }
}
