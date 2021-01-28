using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public record Category : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }

        public int? ParentId { get; set; }
    }
}
