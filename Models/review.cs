using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manageProducts.Models
{
    public class review
    {
        public long Id { get; set; }
        public long CustomerID { get; set; }
        public long ProductID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public bool Visible { get; set; }
    }
}
