using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore
{
    public record ProductFilter
    {
        public int? CategoryId { get; init; }

        public int? BrandId { get; init; }
    }
}
