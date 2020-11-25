using ECommerce.Api.Orders.Databases.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Databases
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Tables.Order> Orders { get; set; }
        public DbSet<Tables.OrderItem> OrderItems { get; set; }

        public OrderDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();
        }
    }
}
