using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using LogiTrack.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Tests
{
    [TestFixture]
    public class RequestServiceTests
    {
        private IRepository repository;
        private IRequestService requestService;
        private ApplicationDbContext dbContext;
        private GeocodingService geocodingService;
        private HttpClient httpClient;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                         .Options;

            dbContext = new ApplicationDbContext(options);
            repository = new Repository(dbContext);
            httpClient = new HttpClient();
            geocodingService = new GeocodingService(httpClient);
            requestService = new RequestService(repository, geocodingService);
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
                Id = "20450cff-816f-49c8-0000-1c603aec0301",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
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
                User = clientCompanyUser
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
                UserId = clientCompanyUser.Id,
                Salary = 3000.0m,
                Age = 30,
                YearOfExperience = 5,
                MonthsOfExperience = 6,
                IsAvailable = true,
                Preferrences = "No night shifts",
                User = clientCompanyUser
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
            };
            var offer2 = new LogisticsSystem.Infrastructure.Data.DataModels.Offer
            {
                RequestId = request2.Id,
                FinalPrice = 1500.0m,
                OfferStatus = "Approved",
                OfferNumber = "OFFER0002",
                OfferDate = DateTime.Now.AddDays(-16),
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
        public async Task MakeRequestAsync_ShouldCreateRequest()
        {
            var model = new MakeRequestViewModel
            {
                PickupCity = "Gotham",
                PickupCountry = "USA",
                PickupStreet = "456 Side St",
                PickupLatitude = 40.7128,
                PickupLongitude = -74.0060,
                DeliveryCity = "Star City",
                DeliveryCountry = "USA",
                DeliveryStreet = "789 Elm St",
                DeliveryLatitude = 37.7749,
                DeliveryLongitude = -122.4194,
                CargoType = "Standard",
                TypeOfGoods = "Electronics",
                Type = "Domestic",
                ApproximatePrice = 500,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                SpecialInstructions = "Handle with care"
            };

            await requestService.MakeRequestAsync(model, "clientcompany1");

            var request = dbContext.Requests.FirstOrDefault(r => r.RerefenceNumber == "R0001");
            Assert.NotNull(request);
            Assert.AreEqual("Gotham", request.PickupAddress.City);
            Assert.AreEqual("Star City", request.DeliveryAddress.City);
        }

        [Test]
        public async Task MakeRequestAsync_ShouldCreatePickupAndDeliveryAddresses()
        {
            var model = new MakeRequestViewModel
            {
                PickupCity = "Gotham",
                PickupCountry = "USA",
                PickupStreet = "456 Side St",
                PickupLatitude = 40.7128,
                PickupLongitude = -74.0060,
                DeliveryCity = "Star City",
                DeliveryCountry = "USA",
                DeliveryStreet = "789 Elm St",
                DeliveryLatitude = 37.7749,
                DeliveryLongitude = -122.4194
            };

            await requestService.MakeRequestAsync(model, "clientcompany1");

            var pickupAddress = dbContext.Addresses.FirstOrDefault(a => a.City == "Gotham");
            var deliveryAddress = dbContext.Addresses.FirstOrDefault(a => a.City == "Star City");

            Assert.NotNull(pickupAddress);
            Assert.NotNull(deliveryAddress);
            Assert.AreEqual("456 Side St", pickupAddress.Street);
            Assert.AreEqual("789 Elm St", deliveryAddress.Street);
        }

        [Test]
        public async Task MakeRequestAsync_ShouldAddStandardCargoWhenProvided()
        {
            var model = new MakeRequestViewModel
            {
                PickupCity = "Gotham",
                PickupCountry = "USA",
                PickupStreet = "456 Side St",
                PickupLatitude = 40.7128,
                PickupLongitude = -74.0060,
                DeliveryCity = "Star City",
                DeliveryCountry = "USA",
                DeliveryStreet = "789 Elm St",
                DeliveryLatitude = 37.7749,
                DeliveryLongitude = -122.4194,
                CargoType = "Standard",
                TypeOfGoods = "Electronics",
                Type = "Domestic",
                ApproximatePrice = 500,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                SpecialInstructions = "Handle with care",
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 100,
                WeightOfPallets = 500,
                NumberOfPallets = 5
            };

            await requestService.MakeRequestAsync(model, "clientcompany1");

            var standartCargo = dbContext.StandartCargos.FirstOrDefault();
            Assert.NotNull(standartCargo);
            Assert.AreEqual(120, standartCargo.PalletLength);
            Assert.AreEqual(80, standartCargo.PalletWidth);
        }

        [Test]
        public async Task GetRequestsForCompanyAsync_ShouldReturnRequestsFilteredByPrice()
        {
            var minPrice = 200m;
            var maxPrice = 1200m;

            var requests = await requestService.GetRequestsForCompanyAsync("clientcompany1", minPrice: minPrice, maxPrice: maxPrice);

            Assert.IsNotEmpty(requests);
            foreach (var request in requests)
            {
                var price = decimal.Parse(request.TotalWeight); 
                Assert.That(price, Is.GreaterThanOrEqualTo(minPrice));
                Assert.That(price, Is.LessThanOrEqualTo(maxPrice));
            }
        }

        [Test]
        public async Task GetRequestsForCompanyAsync_ShouldReturnRequestsFilteredByWeight()
        {
            var minWeight = 300;
            var maxWeight = 600;

            var requests = await requestService.GetRequestsForCompanyAsync("clientcompany1", minWeight: minWeight, maxWeight: maxWeight);

            Assert.IsNotEmpty(requests);
            foreach (var request in requests)
            {
                var weight = double.Parse(request.TotalWeight);
                Assert.That(weight, Is.GreaterThanOrEqualTo(minWeight));
                Assert.That(weight, Is.LessThanOrEqualTo(maxWeight));
            }
        }

        [Test]
        public async Task GetRequestsForCompanyAsync_ShouldReturnRequestsFilteredByDateRange()
        {
            var startDate = DateTime.Now.AddDays(-21);
            var endDate = DateTime.Now.AddDays(-15);

            var requests = await requestService.GetRequestsForCompanyAsync("clientcompany1", startDate: startDate, endDate: endDate);

            Assert.IsNotEmpty(requests);
            foreach (var request in requests)
            {
                Assert.That(request.CreationDate, Is.GreaterThanOrEqualTo(startDate.ToString("dd-MM-yyyy")));
                Assert.That(request.CreationDate, Is.LessThanOrEqualTo(endDate.ToString("dd-MM-yyyy")));
            }
        }

        [Test]
        public async Task GetRequestsForCompanyAsync_ShouldReturnRequestsFilteredByAddress()
        {
            var deliveryAddress = "Star City";
            var pickupAddress = "Gotham";

            var requests = await requestService.GetRequestsForCompanyAsync("clientcompany1", deliveryAddress: deliveryAddress, pickupAddress: pickupAddress);

            Assert.IsNotEmpty(requests);
            foreach (var request in requests)
            {
                Assert.IsTrue(request.DeliveryAddress.Contains(deliveryAddress));
                Assert.IsTrue(request.PickupAddress.Contains(pickupAddress));
            }
        }

        [Test]
        public async Task GetRequestsForCompanyAsync_ShouldReturnEmptyListWhenNoMatchingRequests()
        {
            var requests = await requestService.GetRequestsForCompanyAsync("clientcompany1", minPrice: 2000m);

            Assert.IsEmpty(requests);
        }

        [Test]
        public async Task GetRequestsForCompanyBySearchTermAsync_ShouldReturnRequestsWhenSearchTermMatches()
        {
            var companyUsername = "clientcompany1";
            var searchTerm = "Gotham";  

            var result = await requestService.GetRequestsForCompanyBySearchTermAsync(companyUsername, searchTerm);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.All(r =>
                r.PickupAddress.ToLower().Contains(searchTerm.ToLower()) ||
                r.DeliveryAddress.ToLower().Contains(searchTerm.ToLower())
            ));
        }

        [Test]
        public async Task GetRequestsForCompanyBySearchTermAsync_ShouldReturnEmptyListWhenNoMatch()
        {
            var companyUsername = "clientcompany1";
            var searchTerm = "NonExistentCity";  

            var result = await requestService.GetRequestsForCompanyBySearchTermAsync(companyUsername, searchTerm);

            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetRequestsForCompanyBySearchTermAsync_ShouldReturnEmptyListWhenSearchTermIsNull()
        {
            var companyUsername = "clientcompany1";
            string? searchTerm = null;

            var result = await requestService.GetRequestsForCompanyBySearchTermAsync(companyUsername, searchTerm);

            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetRequestsForLogisticsBySearchTermAsync_ShouldReturnMultipleRequests_WhenSearchTermMatches()
        {
            var searchTerm = "Standard"; 

            var result = await requestService.GetRequestsForLogisticsBySearchTermAsync(searchTerm);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count()); 
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
