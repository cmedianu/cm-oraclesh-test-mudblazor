using Xunit;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class OracleAppDbContextTests
    {
        private DbContextOptions<AppDbContext> GetOracleOptions()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<OracleAppDbContextTests>()
                .Build();
            var connStr = config.GetConnectionString("OracleSH");
            if (string.IsNullOrEmpty(connStr))
                throw new InvalidOperationException("OracleSH connection string not found in user secrets.");
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseOracle(connStr)
                .Options;
        }

        //[Fact(Skip = "Enable and configure Oracle connection to run this test.")]
        [Fact]
        public void CanSelectCustomers()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var customers = context.Customers.Take(5).ToList();
                Assert.NotEmpty(customers);
            }
        }

        [Fact]
        public void CanSelectCountries()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var countries = context.Countries.Take(5).ToList();
                Assert.NotEmpty(countries);
            }
        }

        [Fact]
        public void CanSelectSales()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var sales = context.Sales.Take(5).ToList();
                Assert.NotEmpty(sales);
            }
        }

        [Fact]
        public void CanSelectCustomerWithCountry()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.Include(c => c.Country).FirstOrDefault();
                Assert.NotNull(customer);
                Assert.NotNull(customer.Country);
            }
        }

        [Fact]
        public void CanSelectCustomerWithSales()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.Include(c => c.Sales).FirstOrDefault(c => c.Sales.Any());
                Assert.NotNull(customer);
                Assert.NotNull(customer.Sales);
                Assert.NotEmpty(customer.Sales);
            }
        }

        [Fact]
        public void CanSelectSaleWithCustomer()
        {
            var options = GetOracleOptions();
            using (var context = new AppDbContext(options))
            {
                var sale = context.Sales.Include(s => s.Customer).FirstOrDefault();
                Assert.NotNull(sale);
                Assert.NotNull(sale.Customer);
            }
        }
    }
} 