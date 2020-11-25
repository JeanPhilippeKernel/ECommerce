using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrderProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.OrderModel> Results, string ErrorMessage)> GetAllOrderAsync();
        Task<(bool IsSuccess, Models.OrderModel Results, string ErrorMessage)> GetOneOrderAsync(int orderId);
        Task<(bool IsSuccess, IEnumerable<Models.OrderModel> Results, string ErrorMessage)> GetOneOrderByCustomerAsync(int customerId);
    }
}
