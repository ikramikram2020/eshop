using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eshop2.Models
{
    public class eshopContext : DbContext
    {
        public eshopContext() : base("name=eshopDB") { }
       
        public DbSet<product> Products { get; set; } 
    }
}
