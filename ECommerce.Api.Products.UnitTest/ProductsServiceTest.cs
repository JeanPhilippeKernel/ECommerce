using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ECommerce.Api.Products;
using System.Threading.Tasks;
using System.Linq;

namespace ECommerce.Api.Products.UnitTest
{
    public class ProductsServiceTest
    {
     
        [Fact]
        public async Task GetProductReturnAllProductsAsync()
            
        {
            var dbContextOption =  new DbContextOptionsBuilder<Databases.ProductsDbContext>()
                .UseInMemoryDatabase("ProductDb");
            using var productDbContext = new Databases.ProductsDbContext(dbContextOption.Options); 

            var productProfile =  new Profiles.ProductProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(f => f.AddProfile(productProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var productProvider =  new Providers.ProductProvider(productDbContext, null, mapper);


            var products  = await productProvider.GetAllProductsAsync();

            Assert.True(products.IsSuccess);
            Assert.NotNull(products.Result);
            Assert.True(products.Result.Any());
            Assert.Null(products.ErrorMessage);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetProductReturnOneProductAsync(int productId)
            
        {
            var dbContextOption =  new DbContextOptionsBuilder<Databases.ProductsDbContext>()
                .UseInMemoryDatabase("GetProductReturnAllProducts");
            using var productDbContext = new Databases.ProductsDbContext(dbContextOption.Options); 

            var productProfile =  new Profiles.ProductProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(f => f.AddProfile(productProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var productProvider =  new Providers.ProductProvider(productDbContext, null, mapper);

            var product  = await productProvider.GetOneProductsAsync(productId);

            Assert.True(product.IsSuccess);
            Assert.NotNull(product.Result);
            Assert.True(product.Result.Id == productId);
            Assert.Null(product.ErrorMessage);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-3)]
        public async Task GetProductReturnNullProductAsync(int productId)
            
        {
            var dbContextOption =  new DbContextOptionsBuilder<Databases.ProductsDbContext>()
                .UseInMemoryDatabase("GetProductReturnAllProducts");
            using var productDbContext = new Databases.ProductsDbContext(dbContextOption.Options); 

            var productProfile =  new Profiles.ProductProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(f => f.AddProfile(productProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var productProvider =  new Providers.ProductProvider(productDbContext, null, mapper);

            var product  = await productProvider.GetOneProductsAsync(productId);

            Assert.False(product.IsSuccess);
            Assert.Null(product.Result);
            Assert.NotNull(product.ErrorMessage);
        }    
    }
}