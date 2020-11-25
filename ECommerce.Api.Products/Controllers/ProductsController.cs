using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductProvider _productProvider;
        public ProductsController(IProductProvider productProvider) => _productProvider =  productProvider;


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products =  await _productProvider.GetAllProductsAsync();
            if(products.IsSuccess) return Ok(products.Result);
             
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productProvider.GetOneProductsAsync(id);
            if(product.IsSuccess) return Ok(product.Result);
            
            return NotFound();
        }

    }
}
