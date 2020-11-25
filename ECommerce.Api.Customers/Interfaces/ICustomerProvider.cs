using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface ICustomerProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.CustomerModel> Result, string ErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess, Models.CustomerModel Result, string ErrorMessage)> GetOneCustomerAsync(int customerId);
    }
}
