using System.Collections.Generic;
using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public record Brand : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
