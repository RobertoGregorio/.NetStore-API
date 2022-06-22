using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;

namespace Api.Domain
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
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}