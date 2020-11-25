using AutoMapper;
using ECommerce.Api.Customers.Databases.Tables;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        readonly Databases.CustomerDbContext _context;
        readonly ILogger<Databases.CustomerDbContext> _logger;
        readonly IMapper _mapper;

        public CustomerProvider(
            Databases.CustomerDbContext context, 
            ILogger<Databases.CustomerDbContext> logger,
            IMapper mapper
            )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;


            _context.Database.EnsureCreated();
        }

        public async Task<(bool IsSuccess, IEnumerable<CustomerModel> Result, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                var result =  await _context.Customers.ToListAsync();
                if(result != null && result.Any())
                {
                    var output = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerModel>>(result);
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

        public async Task<(bool IsSuccess, CustomerModel Result, string ErrorMessage)> GetOneCustomerAsync(int customerId)
        {
            try
            {
                var result =  await _context.Customers.FindAsync(customerId);
                if(result != null)
                {
                    var output = _mapper.Map<Customer, CustomerModel>(result);
                    return (true, output, null);
                }
                return (false, null, "Not found");
            }

            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }            
        }
    }
}
