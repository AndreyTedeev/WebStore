using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Base.Interfaces
{
    interface IOrderedEntity
    {
        public int OrderNumber { get; set; }
    }
}
