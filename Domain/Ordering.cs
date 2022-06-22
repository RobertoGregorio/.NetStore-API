using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Enums;
using Api.Interfaces;

namespace Api.Domain
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