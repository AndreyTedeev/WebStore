using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public record BrandViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }
    }
}
