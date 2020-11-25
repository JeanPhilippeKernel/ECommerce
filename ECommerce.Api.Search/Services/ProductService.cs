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
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IHttpClientFactory httpClientFactory, 
            ILogger<ProductService> logger
            )
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Results, string ErrorMessage)> 
            GetProductAsync(int customerId)
        {
                  throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Results, string ErrorMessage)> 
            GetProductAsync()
        {
            try
            {
                var  client = _httpClientFactory.CreateClient("ProductsService");
                var response = await client.GetAsync("api/products");
                if(response.IsSuccessStatusCode)
                {
                    var content =  await response.Content.ReadAsByteArrayAsync();
                    var option =  new JsonSerializerOptions { PropertyNameCaseInsensitive =  true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Models.ProductModel>>(content, option);

                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false,  null, null);
            }
        }
    }
}
