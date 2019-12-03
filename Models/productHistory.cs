using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manageProducts.Models
{
    public class productHistory
    {
        public long id { get; set; }
        public long productId { get; set; }
        public DateTime dateChange { get; set; }
        public double price { get; set; }
    }
}
