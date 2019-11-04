using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Products.InMemory.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
