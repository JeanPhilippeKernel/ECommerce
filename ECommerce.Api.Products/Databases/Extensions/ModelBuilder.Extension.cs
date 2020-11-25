using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Databases.Extensions
{
    public static class ModelBuilderExtension
    {

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Tables.Product>().HasData(
                  new Tables.Product { Id = 1, Name = "Keyboard", Inventory = 2, Price = 3M},
                  new Tables.Product { Id = 2, Name = "Mouse", Inventory = 20, Price = 120M},
                  new Tables.Product { Id = 3, Name = "Monitor", Inventory = 30, Price = 102M},
                  new Tables.Product { Id = 4, Name = "Hard Drive", Inventory = 400, Price = 22M},
                  new Tables.Product { Id = 5, Name = "RAM", Inventory = 9000, Price = 1M}
                );
        }
    }
}
