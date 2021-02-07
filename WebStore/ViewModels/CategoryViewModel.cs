using System.Collections.Generic;
using System.Linq;

namespace WebStore.ViewModels
{
    public record CategoryViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int OrderNumber { get; init; }

        public CategoryViewModel Parent { get; init; }

        public List<CategoryViewModel> Children { get; } = new List<CategoryViewModel>();

        public int ProductsCount { get; set; }

        public int TotalProductsCount => ProductsCount + Children.Sum((c) => c.TotalProductsCount);

    }
}
