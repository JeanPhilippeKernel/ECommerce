using AutoMapper;
using ECommerce.Api.Orders.Databases;
using ECommerce.Api.Orders.Databases.Tables;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrderProvider : IOrderProvider
    {
        readonly OrderDbContext _context;
        readonly ILogger<OrderDbContext> _logger;
        readonly IMapper _mapper;
        public OrderProvider(
            OrderDbContext context,
            ILogger<OrderDbContext> logger,
            IMapper mapper
            )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

            _context.Database.EnsureCreated();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Results, string ErrorMessage)> GetAllOrderAsync()
        {
            try
            {
                var result =  await _context.Orders.ToListAsync();
                if(result != null && result.Any())
                {
                    var output = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(result);
                    return (true, output, null);
                }
                
               return (false, null, "Not found");

            }

            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, OrderModel Results, string ErrorMessage)> GetOneOrderAsync(int orderId)
        {
            try
            {
                var result =  await _context.Orders.FindAsync(orderId);
                if(result != null)
                {
                    var output = _mapper.Map<Order, OrderModel>(result);
                    return (true, output, null);
                }
                return (false, null, "Not found");
            }

            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }

        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Results, string ErrorMessage)> GetOneOrderByCustomerAsync(int customerId)
        {
            try
            {
                var result = await _context.Orders
                    .Include(e => e.Items)
                    .Where(e => e.CustomerId == customerId)
                    .ToListAsync();
                
                if(result != null && result.Any())
                {
                    var output =  _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(result);
                    return (true, output, null);
                }
                
                return (false, null, "Not found");

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
