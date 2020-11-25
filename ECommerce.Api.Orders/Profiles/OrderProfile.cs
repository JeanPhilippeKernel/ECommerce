using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Databases.Tables.Order, Models.OrderModel>();
            CreateMap<Databases.Tables.OrderItem, Models.OrderItemModel>();
        }
    }
}
