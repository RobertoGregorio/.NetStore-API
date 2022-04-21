using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using WebApi.Interfaces;

namespace WebApi.Models
{
    public class Category : IBaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }

        [Required]
        public CategoryType Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }
    }
}