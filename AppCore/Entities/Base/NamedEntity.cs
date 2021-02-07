using System.ComponentModel.DataAnnotations;
using WebStore.Entities.Base.Interfaces;

namespace WebStore.Entities.Base
{
    public abstract record NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
