using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    public interface IProductService
    {
        Task<(bool IsSuccess, IEnumerable<Models.ProductModel> Results, string ErrorMessage)>
            GetProductAsync(int customerId);

        Task<(bool IsSuccess, IEnumerable<Models.ProductModel> Results, string ErrorMessage)>
            GetProductAsync();
    }
}
