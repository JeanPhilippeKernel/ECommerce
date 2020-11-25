using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Databases.Tables
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
