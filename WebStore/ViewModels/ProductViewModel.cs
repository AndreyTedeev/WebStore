using WebStore.Entities;

namespace WebStore.ViewModels
{
    public record ProductViewModel
    {
        private readonly Product _product;

        public ProductViewModel(Product product) => _product = product ?? new();

        public int Id { get => _product.Id; init => _product.Id = value; }

        public string Name { get => _product.Name; init => _product.Name = value; }

        public string ImageUrl { get => _product.ImageUrl; init => _product.ImageUrl = value; }

        public decimal Price { get => _product.Price; init => _product.Price = value; }

        public Product Product => _product;
    }

}
