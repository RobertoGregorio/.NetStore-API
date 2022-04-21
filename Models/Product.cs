using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Models
{
    public class Product : IBaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}