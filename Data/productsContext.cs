using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace manageProducts.Models
{
    public class productsContext : DbContext
    {
        public productsContext (DbContextOptions<productsContext> options)
            : base(options)
        {
        }
        public DbSet<manageProducts.Models.product> product { get; set; }
    }
}
