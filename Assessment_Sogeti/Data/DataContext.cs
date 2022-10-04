using System;
using Assessment_Sogeti.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment_Sogeti.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }  
    }
}

