using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Json
{
    public class JsonInsertProduct
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public string CategoryCode { get; set; }

        public string ImageUrl { get; set; }
        
    }
}