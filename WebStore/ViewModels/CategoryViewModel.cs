using System.Collections.Generic;

namespace WebStore.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int OrderNumber { get; init; }

        public CategoryViewModel Parent { get; init; }

        public List<CategoryViewModel> Children { get; } = new List<CategoryViewModel>();

    }
}
