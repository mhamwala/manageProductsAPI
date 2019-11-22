using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manageProducts.Models
{
    public class product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }
}
