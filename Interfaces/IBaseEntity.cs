using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IBaseEntity
    {
        [Required]
        public long Id { get; set; }
        
    }
}