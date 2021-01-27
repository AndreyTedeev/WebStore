using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Base;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }
    }
}
