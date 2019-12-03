using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using manageProducts.Models;

namespace manageProducts.Data
{
    public class productsHistoryContext : DbContext
    {
        public productsHistoryContext (DbContextOptions<productsHistoryContext> options)
            : base(options)
        {
        }

        public DbSet<manageProducts.Models.productHistory> productHistory { get; set; }
    }
}
