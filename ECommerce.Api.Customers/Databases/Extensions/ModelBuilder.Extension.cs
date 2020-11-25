using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Databases.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Tables.Customer>().HasData(
                new Tables.Customer { Id = 1, Name = "John", Address = "France" },
                new Tables.Customer { Id = 2, Name = "Frank", Address = "USA" },
                new Tables.Customer { Id = 3, Name = "Sarah", Address = "UK" }
                );
        }
    }
}
