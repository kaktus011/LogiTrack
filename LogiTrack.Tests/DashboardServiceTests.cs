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
using System.Collections.Generic;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;

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
                         .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                         .Options;

            dbContext = new ApplicationDbContext(options);
            repository = new Repository(dbContext);
            dashboardService = new DashboardService(repository);
            SeedData();
        }


        private void SeedData()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var hasher = new PasswordHasher<IdentityUser>();
            var clientCompanyUser = new IdentityUser
            {
                UserName = "clientcompany1",
                Email = "clientcompany1@example.com",
                Id = "20450cff-816f-49c8-9546-1c603aec0301",
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };
            clientCompanyUser.PasswordHash = hasher.HashPassword(clientCompanyUser, "clientcompany1");
            dbContext.Users.Add(clientCompanyUser);
            dbContext.SaveChangesAsync();
            var clientCompany = new LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany
            {
                Name = "Client Company 1",
                UserId = clientCompanyUser.Id,
                RegistrationStatus = "Approved",
                ContactPerson = "John Doe",
                AlternativePhoneNumber = "1234567891",
                RegistrationNumber = "REG123456",
                Industry = "Manufacturing",
                Address = new Infrastructure.Data.DataModels.Address { Id = 1, Street = "123 Main St", County = "Central", City = "Metropolis", PostalCode = "10001" },
                CreatedAt = DateTime.Now.AddDays(-20),
            };
            dbContext.ClientCompanies.Add(clientCompany);
            dbContext.SaveChangesAsync();

            var standartCargo = new StandartCargo
            {
                TypeOfPallet = "Euro",
                NumberOfPallets = 5,
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 100,
                PalletVolume = 0.96,
                WeightOfPallets = 500,
                PalletsAreStackable = true
            };
            dbContext.StandartCargos.Add(standartCargo);

            var driver = new Infrastructure.Data.DataModels.Driver
            {
                Name = "John Doe",
                LicenseNumber = "D12345678",
                LicenseExpiryDate = DateTime.Now.AddYears(1),
                UserId = "driverUser1",
                Salary = 3000.0m,
                Age = 30,
                YearOfExperience = 5,
                MonthsOfExperience = 6,
                IsAvailable = true,
                Preferrences = "No night shifts"
            };
            dbContext.Drivers.Add(driver);

            var vehicle = new LogisticsSystem.Infrastructure.Data.DataModels.Vehicle
            {
                RegistrationNumber = "ABC123",
                EmissionFactor = 2.63,
                VehicleType = "Truck",
                Length = 12.0,
                Width = 2.5,
                Height = 2.8,
                Volume = 84.0,
                EuroPalletCapacity = 33,
                IndustrialPalletCapacity = 20,
                ArePalletsStackable = true,
                MaxWeightCapacity = 18000,
                FuelConsumptionPer100Km = 12.5,
                VehicleStatus = "Available",
                LastYearMaintenance = DateTime.Now.AddMonths(-3),
                KilometersDriven = 150000,
                KilometersLeftToChangeParts = 50000,
                PurchasePrice = 75000.0m,
                ContantsExpenses = 5000.0m
            };
            dbContext.Vehicles.Add(vehicle);

            dbContext.SaveChangesAsync();

            var request = new LogisticsSystem.Infrastructure.Data.DataModels.Request
            {
                RerefenceNumber = "R0001",
                ClientCompanyId = clientCompany.Id,
                CargoType = "Standard",
                TypeOfGoods = "Electronics",
                Type = "Domestic",
                PickupAddress = new Infrastructure.Data.DataModels.Address { Id = 2, Street = "456 Side St", County = "Westside", City = "Gotham", PostalCode = "10002", Latitude = 40.7128, Longitude = -74.0060 },
                DeliveryAddress = new Infrastructure.Data.DataModels.Address { Id = 3, Street = "789 Elm St", County = "Northside", City = "Star City", PostalCode = "10003", Latitude = 37.7749, Longitude = -122.4194 },
                SharedTruck = false,
                ApproximatePrice = 500,
                CalculatedPrice = 450,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                Status = "Pending",
                SpecialInstructions = "Handle with care",
                IsRefrigerated = false,
                CreatedAt = DateTime.Now.AddDays(-20),
                StandartCargoId = standartCargo.Id,
                TotalWeight = 300,
                TotalVolume = 12,
                Kilometers = 500
            };
            dbContext.Requests.Add(request);

            var request2 = new LogisticsSystem.Infrastructure.Data.DataModels.Request
            {
                ClientCompanyId = clientCompany.Id,
                RerefenceNumber = "R0002",
                CargoType = "Standard",
                TypeOfGoods = "Furniture",
                Type = "International",
                PickupAddress = new Infrastructure.Data.DataModels.Address { Id = 5, Street = "202 Maple St", County = "Southend", City = "Smallville", PostalCode = "10005", Latitude = 38.0293, Longitude = -78.4767 },
                DeliveryAddress = new Infrastructure.Data.DataModels.Address { Id = 6, Street = "303 Oak St", County = "Old Town", City = "Bludhaven", PostalCode = "10006", Latitude = 36.8508, Longitude = -76.2859 },
                SharedTruck = true,
                ApproximatePrice = 1200,
                CalculatedPrice = 1150,
                ExpectedDeliveryDate = DateTime.Now.AddDays(10),
                Status = "Accepted",
                SpecialInstructions = "Keep dry",
                IsRefrigerated = false,
                CreatedAt = DateTime.Now.AddDays(-21),
                TotalWeight = 500,
                TotalVolume = 20,
                Kilometers = 1000
            };
            dbContext.Requests.Add(request2);
            dbContext.SaveChangesAsync();

            var nonStandardCargo1 = new NonStandardCargo
            {
                Length = 120,
                Width = 100,
                Height = 150,
                Volume = 1.8,
                Weight = 300,
                Description = "Large industrial machine",
                RequestId = request2.Id
            };

            var nonStandardCargo2 = new NonStandardCargo
            {
                Length = 90,
                Width = 75,
                Height = 80,
                Volume = 0.6,
                Weight = 120,
                Description = "Auxiliary machine part",
                RequestId = request2.Id
            };
            dbContext.NonStandardCargos.Add(nonStandardCargo1);
            dbContext.NonStandardCargos.Add(nonStandardCargo2);
            dbContext.SaveChangesAsync();

            var offer1 = new LogisticsSystem.Infrastructure.Data.DataModels.Offer
            {
                RequestId = request.Id,
                FinalPrice = 1200.0m,
                OfferStatus = "Pending",
                OfferDate = DateTime.Now.AddDays(-15),
                OfferNumber = "OFFER0001",
                Notes = "Initial offer for Request 1",
                StartDate = DateTime.Now.AddDays(-10),
            };
            var offer2 = new LogisticsSystem.Infrastructure.Data.DataModels.Offer
            {
                RequestId = request2.Id,
                FinalPrice = 1500.0m,
                OfferStatus = "Approved",
                OfferNumber = "OFFER0002",
                OfferDate = DateTime.Now.AddDays(-16),
                StartDate = DateTime.Now.AddDays(-11),
                Notes = "Offer accepted for Request 2",
            };
            dbContext.Offers.Add(offer1);
            dbContext.Offers.Add(offer2);
            dbContext.SaveChangesAsync();

            var delivery1 = new Infrastructure.Data.DataModels.Delivery
            {
                CarbonEmission = 38.7,
                VehicleId = vehicle.Id,
                DriverId = driver.Id,
                OfferId = offer1.Id,
                Status = "Delivered",
                TotalExpenses = 500.00m,
                Profit = 750.00m,
                ReferenceNumber = "DEL0001",
                DeliveryStep = 4,
                ActualDeliveryDate = DateTime.Now.AddDays(-1)
            };
            var delivery2 = new Infrastructure.Data.DataModels.Delivery
            {
                CarbonEmission = 40.0,
                VehicleId = vehicle.Id,
                DriverId = driver.Id,
                OfferId = offer2.Id,
                Status = "In transit",
                TotalExpenses = 450.00m,
                Profit = 700.00m,
                ReferenceNumber = "DEL0002",
                DeliveryStep = 2,
                ActualDeliveryDate = DateTime.Now.AddDays(-2)
            };
            dbContext.Deliveries.Add(delivery1);
            dbContext.Deliveries.Add(delivery2);
            dbContext.SaveChangesAsync();

            var invoice1 = new Invoice
            {
                PaidOnTime = true,
                PaidDate = DateTime.Now.AddDays(-5),
                DeliveryId = delivery1.Id,
                InvoiceNumber = "INV001",
                InvoiceDate = DateTime.Now.AddDays(-10),
                Description = "Invoice for Delivery 1",
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq",
                Status = "Paid",
                IsPaid = true
            };
            dbContext.Invoices.Add(invoice1);

            var cashRegister1 = new Infrastructure.Data.DataModels.CashRegister
            {
                DeliveryId = delivery1.Id,
                Description = "Fuel Expense",
                Type = "Vehicle Expenses",
                Amount = 100.00m,
                DateSubmitted = DateTime.Now.AddDays(-5),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            var cashRegister2 = new Infrastructure.Data.DataModels.CashRegister
            {
                DeliveryId = delivery1.Id,
                Description = "Toll Fee",
                Type = "Vehicle Expenses",
                Amount = 50.00m,
                DateSubmitted = DateTime.Now.AddDays(-4),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            dbContext.CashRegisters.Add(cashRegister1);
            dbContext.CashRegisters.Add(cashRegister2);

            var pricesPerSize = new PricesPerSize
            {
                VehicleId = vehicle.Id,
                QuotientForDomesticNotSharedTruck = 1.2,
                QuotientForDomesticSharedTruck = 0.9,
                QuotientForInternationalNotSharedTruck = 1.5,
                QuotientForInternationalSharedTruck = 1.1,
            };
            dbContext.PricesPerSize.Add(pricesPerSize);

            var fuelPrice1 = new Infrastructure.Data.DataModels.FuelPrice
            {
                Price = 2.50m,
                Date = DateTime.Now.AddDays(-3)
            };
            dbContext.FuelPrices.Add(fuelPrice1);

            var deliveryTracking1 = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = delivery1.Id,
                DriverId = driver.Id,
                StatusUpdate = "Delivered",
                Notes = "Delivery completed successfully.",
                Timestamp = DateTime.Now.AddDays(-5),
                Latitude = 42.6977,
                Longitude = 23.3219,
                Address = "Sofia, Bulgaria"
            };
            var DeliveryTracking2 = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = delivery2.Id,
                DriverId = driver.Id,
                StatusUpdate = "In transit",
                Notes = "Delivery scheduled.",
                Timestamp = DateTime.Now.AddDays(-4),
                Latitude = 43.2141,
                Longitude = 27.9147,
                Address = "Varna, Bulgaria"
            };
            dbContext.DeliveryTrackings.Add(deliveryTracking1);
            dbContext.DeliveryTrackings.Add(DeliveryTracking2);

            var calendarEvent1 = new Infrastructure.Data.DataModels.CalendarEvent
            {
                Title = "Monthly Payment Due",
                Date = DateTime.Now.AddMonths(-1),
                EventType = "Paid",
                UserId = clientCompanyUser.Id
            };
            dbContext.CalendarEvents.Add(calendarEvent1);

            dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetAccountantDashboardAsync_ShouldReturnCorrectData()
        {
            var result = await dashboardService.GetAccountantDashboardAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.NewFinishedDeliveriesFromLastWeek); 
            Assert.AreEqual(0, result.NotPaidDeliveriesCount); 
            Assert.AreEqual(1, result.InvoicesCount); 
            Assert.AreEqual(1, result.InvoicesCountFromLastMonth);
            Assert.AreEqual("0", result.DueAmountForDeliveries); 
            Assert.AreEqual(0, result.Last5NotPaidInvoices.Count);
            Assert.AreEqual(1, result.Last5NewDeliveries.Count);
            Assert.AreEqual("Star City, Northside ", result.Last5NewDeliveries[0].DeliveryAddress);
            Assert.AreEqual("Gotham, Westside ", result.Last5NewDeliveries[0].PickupAddress);
        }

        [Test]
        public async Task GetClientCompanyDashboardAsync_ShouldReturnCorrectData()
        {
            var username = "clientcompany1";

            var result = await dashboardService.GetClientCompanyDashboardAsync(username);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.LastFivePendingOffers); 
            Assert.IsNotNull(result.LastFiveDeliveries);
            Assert.IsNotNull(result.LastFiveInvoices);

            Assert.AreEqual(1, result.LastFivePendingOffers.Count());
            Assert.AreEqual(2, result.LastFiveDeliveries.Count());
            Assert.AreEqual(1, result.LastFiveInvoices.Count());
            Assert.AreEqual(0m, result.DueAmountForDeliveries);
            Assert.AreEqual(2, result.RequestsCount);
            Assert.AreEqual(2, result.RequestsLastMonthCount);
            Assert.AreEqual(1, result.BookedOffersCount);
            Assert.AreEqual(1, result.BookedOffersLastMonthCount);
            Assert.AreEqual(1, result.InvoicesCount);
            Assert.AreEqual(1, result.InvoiceLastMonthCount);
        }
        [Test]
        public async Task GetDriverDashboardAsync_ShouldReturnCorrectData()
        {
            var username = "driverUser1"; 

            var result = await dashboardService.GetDriverDashboardAsync(username);

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.KilometersDriven); 
            Assert.AreEqual(50, result.KilometersDrivenlastMonth); 
            Assert.AreEqual(1, result.NewDeliveriesCount); 

            Assert.IsNotNull(result.LastDeliveries);
            Assert.AreEqual(1, result.LastDeliveries.Count); 
            Assert.AreEqual("Test Company", result.LastDeliveries[0].ClientCompanyName);
            Assert.AreEqual("Pickup St, Gotham, Westside", result.LastDeliveries[0].PickupAddress);
            Assert.AreEqual("Delivery St, Star City, Northside", result.LastDeliveries[0].DeliveryAddress);
            Assert.AreEqual("DEL123", result.LastDeliveries[0].ReferenceNumber);

            Assert.IsNotNull(result.NewDeliveries);
            Assert.AreEqual(1, result.NewDeliveries.Count);
            Assert.AreEqual("Test Company", result.NewDeliveries[0].ClientCompanyName);
            Assert.AreEqual("Pickup St, Gotham, Westside", result.NewDeliveries[0].PickupAddress);
            Assert.AreEqual("Delivery St, Star City, Northside", result.NewDeliveries[0].DeliveryAddress);
            Assert.AreEqual("DEL123", result.NewDeliveries[0].ReferenceNumber);
        }

        [Test]
        public async Task GetLogisticsCompanyDashboardAsync_ShouldReturnCorrectData()
        {
            // Act
            var result = await dashboardService.GetLogisticsCompanyDashboardAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.DeliveriesCount); 
            Assert.AreEqual(0, result.DeliveriesLastWeekCount); 
            Assert.AreEqual(0, result.PendingRegistrationsCount);
            Assert.AreEqual(2, result.RequestsCount); 
            Assert.AreEqual(0, result.RequestsLastWeekCount); 

            Assert.IsNotNull(result.DeliveresWithVehicles);
            Assert.AreEqual(2, result.DeliveresWithVehicles.Count); 
            Assert.AreEqual("ABC123", result.DeliveresWithVehicles[0].VehicleRegistrationNumber); 
            Assert.AreEqual(" Bludhaven, Old Town", result.DeliveresWithVehicles[0].DeliveryAddress);
            Assert.AreEqual(" Smallville, Southend", result.DeliveresWithVehicles[0].PickupAddress);

            Assert.IsNotNull(result.Last5BookedOffers);
            Assert.AreEqual(2, result.Last5BookedOffers.Count);
            Assert.AreEqual("OFFER0002", result.Last5BookedOffers[0].ReferenceNumber); 
            Assert.AreEqual("Smallville, Southend", result.Last5BookedOffers[0].PickupAddress);
            Assert.AreEqual(" Bludhaven, Old Town", result.Last5BookedOffers[0].DeliveryAddress);
        }



        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}