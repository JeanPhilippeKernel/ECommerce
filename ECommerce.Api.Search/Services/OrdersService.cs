using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OrdersService> _logger;

        public OrdersService (
            IHttpClientFactory httpClientFactory, 
            ILogger<OrdersService> logger
            )
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSucces, IEnumerable<OrderModel> Result, string ErrorMessage)> 
            GetOrdersAsync(int customerId)
        {
            try
            {
                var client =  _httpClientFactory.CreateClient("OrdersService");
                var response =  await client.GetAsync($"api/orders/customers/{customerId}");

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option =  new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result =  JsonSerializer.Deserialize<IEnumerable<OrderModel>>(content, option);
                
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
