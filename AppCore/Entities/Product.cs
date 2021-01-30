using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public record Product : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
