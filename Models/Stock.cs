using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Models
{
    public class Stock : IBaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }
        
        [Required]
        public long ProductId { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}