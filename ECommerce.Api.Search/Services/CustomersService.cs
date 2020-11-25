﻿using ECommerce.Api.Search.Interfaces;
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
    public class CustomersService : ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(
            IHttpClientFactory httpClientFactory,
            ILogger<CustomersService> logger
            )
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSucces, CustomerModel Result, string ErrorMessage)> 
            GetCustomersAsync(int customerId)
        {
            try
            {
                var client =  _httpClientFactory.CreateClient("CustomersService");
                var response =  await client.GetAsync($"api/customers/{customerId}");
                if(response.IsSuccessStatusCode)
                {
                    var content =  await response.Content.ReadAsByteArrayAsync();
                    var option =  new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<CustomerModel>(content, option);

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
