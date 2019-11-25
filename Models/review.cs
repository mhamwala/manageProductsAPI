using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manageProducts.Models
{
    public class review
    {
        public long Id { get; set; }
        public long customerID { get; set; }
        public long productID { get; set; }
        public int Rating { get; set; }
        public string comments { get; set; }
        public bool visible { get; set; }
    }
}
