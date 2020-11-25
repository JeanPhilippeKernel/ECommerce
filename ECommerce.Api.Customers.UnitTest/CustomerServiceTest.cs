
using ECommerce.Api.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Customers.UnitTest
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task GetCustomerReturnAllCustomersAsync()
        {
            var contextOption =  new DbContextOptionsBuilder<Databases.CustomerDbContext>()
                .UseInMemoryDatabase("CustomerDb");
            var customerDbContext = new Databases.CustomerDbContext(contextOption.Options);

            var customerProfile = new Profiles.CustomerProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(c => c.AddProfile(customerProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var provider =  new Providers.CustomerProvider(customerDbContext, null, mapper);
            var customers = await  provider.GetCustomersAsync();

            Assert.True(customers.IsSuccess);
            Assert.NotNull(customers.Result);
            Assert.True(customers.Result.Any());
            Assert.Null(customers.ErrorMessage);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetCustomerReturnOneCustomerAsync(int customerId)
        {
            var contextOption =  new DbContextOptionsBuilder<Databases.CustomerDbContext>()
                .UseInMemoryDatabase("CustomerDb");
            var customerDbContext = new Databases.CustomerDbContext(contextOption.Options);

            var customerProfile = new Profiles.CustomerProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(c => c.AddProfile(customerProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var provider =  new Providers.CustomerProvider(customerDbContext, null, mapper);
            var customers = await  provider.GetOneCustomerAsync(customerId);

            Assert.True(customers.IsSuccess);
            Assert.NotNull(customers.Result);
            Assert.True(customers.Result.Id == customerId);
            Assert.Null(customers.ErrorMessage);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-3)]
        public async Task GetCustomerReturnNullCustomerAsync(int customerId)
        {
            var contextOption =  new DbContextOptionsBuilder<Databases.CustomerDbContext>()
                .UseInMemoryDatabase("CustomerDb");
            var customerDbContext = new Databases.CustomerDbContext(contextOption.Options);

            var customerProfile = new Profiles.CustomerProfile();
            var mapperConfig = new AutoMapper.MapperConfiguration(c => c.AddProfile(customerProfile));
            var mapper =  new AutoMapper.Mapper(mapperConfig);

            var provider =  new Providers.CustomerProvider(customerDbContext, null, mapper);
            var customers = await  provider.GetOneCustomerAsync(customerId);

            Assert.False(customers.IsSuccess);
            Assert.Null(customers.Result);
            Assert.NotNull(customers.ErrorMessage);
        }


    }
}