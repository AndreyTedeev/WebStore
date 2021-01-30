using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public record Category : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
