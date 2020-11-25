using ECommerce.Api.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService _ordersService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public SearchService(
            IOrdersService ordersService, 
            IProductService productService,
            ICustomerService customerService
            )
        {
            _ordersService = ordersService;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<(bool IsSuccess, dynamic Result)> SearchAsync(int customerId)
        {
            var customer = await _customerService.GetCustomersAsync(customerId);
            var orders =  await _ordersService.GetOrdersAsync(customerId);
            var products =  await _productService.GetProductAsync();

            if(orders.IsSucces)
            {
                foreach (var order in orders.Result)
                {
                    order.CustomerName = customer.IsSucces ? 
                        customer.Result?.Name : "Customer information isn't available";

                    foreach (var item in order.Items)
                    {
                        
                         item.ProductName =  products.IsSuccess ? 
                            products.Results.FirstOrDefault(p => p.Id == item.ProductId)?.Name :
                            "Product information isn't available";
                    }
                }
                return (true,  new { Orders = orders.Result });
            }
            return (false, null);
        }
    }
}
