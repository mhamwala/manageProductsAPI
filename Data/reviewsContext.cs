using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using manageProducts.Models;

namespace manageProducts.Data
{
    public class reviewsContext : DbContext
    {
        public reviewsContext (DbContextOptions<reviewsContext> options) : base(options){  }

        public DbSet<manageProducts.Models.review> review { get; set; }
    }
}
