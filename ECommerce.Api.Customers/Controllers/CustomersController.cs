using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly ICustomerProvider _customerProvider;
        public CustomersController(ICustomerProvider provider) => _customerProvider = provider;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerProvider.GetCustomersAsync();
            if(customers.IsSuccess) return Ok(customers.Result);

            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomers(int id)
        {
            var customers = await _customerProvider.GetOneCustomerAsync(id);
            if(customers.IsSuccess) return Ok(customers.Result);

            return NotFound();
        }
    }
}
