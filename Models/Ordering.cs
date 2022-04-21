using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enums;
using WebApi.Interfaces;

namespace WebApi.Models
{
    public class Ordering : IBaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }
        
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public OrderingStatus Status { get; set; }
    }
}