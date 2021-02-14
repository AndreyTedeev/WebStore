using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebStore.Entities.Base;
using WebStore.Entities.Identity;

namespace WebStore.Entities
{
    public record Order : NamedEntity
    {
        public User User { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
