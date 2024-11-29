using Google.Apis.Drive.v3.Data;
using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Infrastructure;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Tests
{
    [TestFixture]
    public class DashboardServiceTests
    {
        private IRepository repository;
        private IDashboardService dashboardService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            dbContext = new ApplicationDbContext(options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            repository = new Repository(dbContext);
            dashboardService = new DashboardService(repository);
        }


        private async Task SeedData()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var clientCompany = new ClientCompany
            {
                Name = "Test Company",
                User = new IdentityUser { Id = "test", UserName = "testuser" }
            };
            dbContext.ClientCompanies.Add(clientCompany);

            var driver = new Driver { IsAvailable = true };
            dbContext.Drivers.Add(driver);

            var vehicle = new Vehicle { IsAvailable = true };
            dbContext.Vehicles.Add(vehicle);

            await dbContext.SaveChangesAsync();  

            var request = new Request
            {
               
                ClientCompanyId = clientCompany.Id,
                PickupAddress = new Address { Street = "Street 1", City = "City 1", County = "County 1" },
                DeliveryAddress = new Address { Street = "Street 2", City = "City 2", County = "County 2" },
                CreatedAt = DateTime.Now.AddDays(-10),
                ExpectedDeliveryDate = DateTime.Now.AddDays(5)
            };
            dbContext.Requests.Add(request);
            await dbContext.SaveChangesAsync();  

            var offer = new Offer
            {
               
                OfferDate = DateTime.Now.AddDays(-5),
                OfferStatus = StatusConstants.Approved,
                RequestId = request.Id,  
                FinalPrice = 100.00M
            };
            dbContext.Offers.Add(offer);
            await dbContext.SaveChangesAsync(); 

            var delivery = new Delivery
            {
                
                OfferId = offer.Id,  
                Status = DeliveryStatusConstants.Delivered,
                ActualDeliveryDate = DateTime.Now.AddDays(-1)
            };
            dbContext.Deliveries.Add(delivery);
            await dbContext.SaveChangesAsync();  

            var invoice = new Invoice
            {
               Id = 20,
                InvoiceDate = DateTime.Now.AddDays(-3),
                IsPaid = false,
                InvoiceNumber = "INV001",
                DeliveryId = delivery.Id  
            };
            dbContext.Invoices.Add(invoice);

            await dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetAccountantDashboardAsync_ShouldReturnCorrectValues()
        {
            await SeedData();

            var result = await dashboardService.GetAccountantDashboardAsync();

            Assert.IsNotNull(result); 

            Assert.AreEqual(2, result.NewFinishedDeliveriesFromLastWeek); 
            Assert.AreEqual(2, result.NotPaidDeliveriesCount);  
            Assert.AreEqual(2, result.InvoicesCount);  
            Assert.AreEqual(2, result.InvoicesCountFromLastMonth); 

            Assert.AreEqual("100.00", result.DueAmountForDeliveries); 

            Assert.AreEqual(2, result.Last5NotPaidInvoices.Count);  
            Assert.AreEqual("01-12-2024", result.Last5NotPaidInvoices[0].CreationDate);  
            Assert.AreEqual(2, result.Last5NewDeliveries.Count);  
        }



        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}