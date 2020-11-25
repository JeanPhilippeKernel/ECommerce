using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderProvider _orderProvider;
        public OrdersController(IOrderProvider provider) => _orderProvider = provider;


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders =  await _orderProvider.GetAllOrderAsync();
            if(orders.IsSuccess) return Ok(orders.Results);

            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orders =  await _orderProvider.GetOneOrderAsync(id);
            if(orders.IsSuccess) return Ok(orders.Results);

            return NotFound();
        }


        [HttpGet, Route("customers/{id}")]
        public async Task<IActionResult> GetOrderByCustomer(int id)
        {
            var orders =  await _orderProvider.GetOneOrderByCustomerAsync(id);
            if(orders.IsSuccess) return Ok(orders.Results);

            return NotFound();
        }
    }
}
