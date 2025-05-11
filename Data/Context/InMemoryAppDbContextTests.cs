using Xunit;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;
using System.Linq;

namespace Data.Context
{
    public class InMemoryAppDbContextTests
    {
        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void CanInsertSelectDeleteCustomer()
        {
            var options = GetInMemoryOptions();
            decimal testId = 9999;
            using (var context = new AppDbContext(options))
            {
                var customer = new Customer { CustId = testId, CustFirstName = "Test", CustLastName = "User" };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.FirstOrDefault(c => c.CustId == testId);
                Assert.NotNull(customer);
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.FirstOrDefault(c => c.CustId == testId);
                Assert.Null(customer);
            }
        }

        [Fact]
        public void CanInsertSelectDeleteCountry()
        {
            var options = GetInMemoryOptions();
            decimal testId = 8888;
            using (var context = new AppDbContext(options))
            {
                var country = new Country { CountryId = testId, CountryName = "Testland" };
                context.Countries.Add(country);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var country = context.Countries.FirstOrDefault(c => c.CountryId == testId);
                Assert.NotNull(country);
                context.Countries.Remove(country);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var country = context.Countries.FirstOrDefault(c => c.CountryId == testId);
                Assert.Null(country);
            }
        }

        [Fact]
        public void CanInsertSelectDeleteSale()
        {
            var options = GetInMemoryOptions();
            decimal testCustId = 7777;
            decimal testProdId = 1;
            decimal testChannelId = 1;
            decimal testPromoId = 1;
            var testTimeId = DateTime.Today;
            using (var context = new AppDbContext(options))
            {
                var sale = new Sale { ProdId = testProdId, CustId = testCustId, TimeId = testTimeId, ChannelId = testChannelId, PromoId = testPromoId, QuantitySold = 5 };
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var sale = context.Sales.FirstOrDefault(s => s.CustId == testCustId && s.ProdId == testProdId && s.TimeId == testTimeId && s.ChannelId == testChannelId && s.PromoId == testPromoId);
                Assert.NotNull(sale);
                context.Sales.Remove(sale);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var sale = context.Sales.FirstOrDefault(s => s.CustId == testCustId && s.ProdId == testProdId && s.TimeId == testTimeId && s.ChannelId == testChannelId && s.PromoId == testPromoId);
                Assert.Null(sale);
            }
        }

        [Fact]
        public void Customer_Country_Navigation_Works()
        {
            var options = GetInMemoryOptions();
            decimal countryId = 1234;
            decimal customerId = 5678;
            using (var context = new AppDbContext(options))
            {
                var country = new Country { CountryId = countryId, CountryName = "NavTestLand" };
                var customer = new Customer { CustId = customerId, CustFirstName = "Nav", CustLastName = "Test", CountryId = countryId };
                context.Countries.Add(country);
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.Include(c => c.Country).FirstOrDefault(c => c.CustId == customerId);
                Assert.NotNull(customer);
                Assert.NotNull(customer.Country);
                Assert.Equal("NavTestLand", customer.Country.CountryName);
            }
        }

        [Fact]
        public void Customer_Sales_Navigation_Works()
        {
            var options = GetInMemoryOptions();
            decimal customerId = 2222;
            decimal prodId = 1;
            decimal channelId = 1;
            decimal promoId = 1;
            var timeId = DateTime.Today;
            using (var context = new AppDbContext(options))
            {
                var customer = new Customer { CustId = customerId, CustFirstName = "SalesNav", CustLastName = "Test" };
                var sale = new Sale { ProdId = prodId, CustId = customerId, TimeId = timeId, ChannelId = channelId, PromoId = promoId, QuantitySold = 2 };
                context.Customers.Add(customer);
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var customer = context.Customers.Include(c => c.Sales).FirstOrDefault(c => c.CustId == customerId);
                Assert.NotNull(customer);
                Assert.NotNull(customer.Sales);
                Assert.Single(customer.Sales);
                Assert.Equal(2, customer.Sales.First().QuantitySold);
            }
        }

        [Fact]
        public void Sale_Customer_Navigation_Works()
        {
            var options = GetInMemoryOptions();
            decimal customerId = 3333;
            decimal prodId = 1;
            decimal channelId = 1;
            decimal promoId = 1;
            var timeId = DateTime.Today;
            using (var context = new AppDbContext(options))
            {
                var customer = new Customer { CustId = customerId, CustFirstName = "SaleNav", CustLastName = "Test" };
                var sale = new Sale { ProdId = prodId, CustId = customerId, TimeId = timeId, ChannelId = channelId, PromoId = promoId, QuantitySold = 3 };
                context.Customers.Add(customer);
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            using (var context = new AppDbContext(options))
            {
                var sale = context.Sales.Include(s => s.Customer).FirstOrDefault(s => s.CustId == customerId && s.ProdId == prodId && s.TimeId == timeId && s.ChannelId == channelId && s.PromoId == promoId);
                Assert.NotNull(sale);
                Assert.NotNull(sale.Customer);
                Assert.Equal("SaleNav", sale.Customer.CustFirstName);
            }
        }
    }
} 