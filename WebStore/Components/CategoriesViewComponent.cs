using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class CategoriesViewComponent : ViewComponent
    {

        private readonly IProductsService _productsService;

        public CategoriesViewComponent(IProductsService productsService)
            => _productsService = productsService;

        /// <summary>
        /// Creates tree of CategoryViewModels and sends to the View
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            var categories = _productsService.GetCategories();
            var parents = categories.Where(c => c.ParentId is null);

            var parentModels = new List<CategoryViewModel>();

            static int CompareByOrder(CategoryViewModel a, CategoryViewModel b) => Comparer<Int32>.Default.Compare(a.OrderNumber, b.OrderNumber);
            foreach (var parent in parents)
            {
                var parentModel = new CategoryViewModel
                {
                    Id = parent.Id,
                    Name = parent.Name,
                    OrderNumber = parent.OrderNumber,
                    ProductsCount = parent.Products.Count()
                };

                var children = categories.Where(c => c.ParentId == parent.Id);
                foreach (var child in children)
                {
                    parentModel.Children.Add(new CategoryViewModel()
                    {
                        Id = child.Id,
                        Name = child.Name,
                        OrderNumber = child.OrderNumber,
                        Parent = parentModel,
                        ProductsCount = child.Products.Count()
                    });
                }
                parentModel.Children.Sort(CompareByOrder);
                parentModels.Add(parentModel);
            }

            parentModels.Sort(CompareByOrder);
            return View(parentModels);
        }
    }
}
