using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Interfaces
{
    public interface IProductProvider
    {
       Task<(bool IsSuccess, IEnumerable<Models.ProductModel> Result, string ErrorMessage)> GetAllProductsAsync();
       Task<(bool IsSuccess, Models.ProductModel Result, string ErrorMessage)> GetOneProductsAsync(int productId);
    }
}
