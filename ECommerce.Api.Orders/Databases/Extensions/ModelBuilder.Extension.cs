using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Databases.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Tables.OrderItem>().HasData(
                        new Tables.OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 56, UnitPrice = 12M },
                        new Tables.OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 500, UnitPrice = 1M },
                        new Tables.OrderItem { Id = 3, OrderId = 1, ProductId = 3, Quantity = 1, UnitPrice = 3M },

                        new Tables.OrderItem { Id = 4, OrderId = 2, ProductId = 1, Quantity = 56, UnitPrice = 12M },
                        new Tables.OrderItem { Id = 5, OrderId = 2, ProductId = 2, Quantity = 500, UnitPrice = 1M },
                        new Tables.OrderItem { Id = 6, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 3M },

                        new Tables.OrderItem { Id = 7, OrderId = 3, ProductId = 1, Quantity = 56, UnitPrice = 12M },
                        new Tables.OrderItem { Id = 8, OrderId = 3, ProductId = 2, Quantity = 500, UnitPrice = 1M },
                        new Tables.OrderItem { Id = 9, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 3M }

                );

            builder.Entity<Tables.Order>().HasData(
                new Tables.Order 
                { 
                    Id = 1, 
                    CustomerId = 1, 
                    OrderDate = DateTime.Now,
                    Total = 230 
                },
                new Tables.Order 
                { 
                    Id = 2, 
                    CustomerId = 2, 
                    OrderDate = DateTime.Now,
                    Total = 100 
                },
                new Tables.Order 
                { 
                    Id = 3, 
                    CustomerId = 3, 
                    OrderDate = DateTime.Now,
                    Total = 23 
                }
                );

        }
    }
}
