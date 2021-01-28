using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public record Product : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
