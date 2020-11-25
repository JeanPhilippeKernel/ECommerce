using AutoMapper;
using ECommerce.Api.Products.Databases.Tables;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly Databases.ProductsDbContext _context;
        private readonly ILogger<ProductProvider> _logger;
        private readonly IMapper _mapper;

        public ProductProvider(
            Databases.ProductsDbContext context,
            ILogger<ProductProvider> logger,
            IMapper mapper
            )
        {
            _context =  context;
            _logger = logger;
            _mapper = mapper;

            _context.Database.EnsureCreated();
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.ProductModel> Result, string ErrorMessage)> GetAllProductsAsync()
        {
            try
            {
                var result =  await _context.Products.ToListAsync();
                if(result != null && result.Any())
                {
                    var output = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(result);
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

        public async Task<(bool IsSuccess, ProductModel Result, string ErrorMessage)> GetOneProductsAsync(int productId)
        {
            try
            {
                var result =  await _context.Products.FindAsync(productId);
                if(result != null)
                {
                    var output = _mapper.Map<Product, ProductModel>(result);
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
