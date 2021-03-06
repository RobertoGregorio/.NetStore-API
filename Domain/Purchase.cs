using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Enums;
using Api.Interfaces;

namespace Api.Domain
{
    public class Purchase : IBaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }

        [Required]
        public long OrderingId { get; set; }

        [Required]
        public Ordering Ordering { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime PayerDate { get; set; }

        [Required]
        public FormPayment FormPayment { get; set; }

    }
}