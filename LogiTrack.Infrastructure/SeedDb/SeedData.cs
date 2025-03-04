﻿using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Infrastructure.SeedDb
{
    public class SeedData
    {
        public IdentityUser ClientCompany1User { get; set; } = null!;
        public IdentityUser LogiticsCompanyUser { get; set; } = null!;
        public IdentityUser SecretaryUser { get; set; } = null!;
        public IdentityUser SpeditorUser { get; set; } = null!;
        public IdentityUser DriverUser1 { get; set; } = null!;
        public IdentityUser DriverUser2 { get; set; } = null!;

        public IdentityRole ClientCompanyRole { get; set; } = null!;
        public IdentityRole LogisticsCompanyRole { get; set; } = null!;
        public IdentityRole AccountRole { get; set; } = null!;
        public IdentityRole SpeditorRole { get; set; } = null!;
        public IdentityRole DriverRole { get; set; } = null!;

        public IdentityUserRole<string> ClientCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> LogisticsCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> AccountantUserRole { get; set; } = null!;
        public IdentityUserRole<string> SpeditorUserRole { get; set; } = null!;
        public IdentityUserRole<string> Driver1UserRole { get; set; } = null!;
        public IdentityUserRole<string> Driver2UserRole { get; set; } = null!;

        public Address Address1 { get; set; } = null!;
        public Address Address2 { get; set; } = null!;
        public Address Address3 { get; set; } = null!;
        public Address Address4 { get; set; } = null!;
        public Address Address5 { get; set; } = null!;
        public Address Address6 { get; set; } = null!;
        public Address Address7 { get; set; } = null!;
        public Address Address8 { get; set; } = null!;
        public Address Address9 { get; set; } = null!;
        public Address Address10 { get; set; } = null!;
        public Address Address11 { get; set; } = null!;
        public Address Address12 { get; set; } = null!;
        public ClientCompany ClientCompany1 { get; set; } = null!;
        public StandartCargo StandartCargo1 { get; set; } = null!;
        public StandartCargo StandartCargo2 { get; set; } = null!;
        public StandartCargo StandartCargo3 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo1 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo2 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo3 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo4 { get; set; } = null!;
        public Request Request1 { get; set; } = null!;
        public Request Request2 { get; set; } = null!;
        public Request Request3 { get; set; } = null!;
        public Request Request4 { get; set; } = null!;
        public Request Request5 { get; set; } = null!;


        public Offer Offer1 { get; set; } = null!;
        public Offer Offer2 { get; set; } = null!;
        public Offer Offer3 { get; set; } = null!;
        public Offer Offer4 { get; set; } = null!;
        public Offer Offer5 { get; set; } = null!;
        public Vehicle Vehicle1 { get; set; } = null!;
        public Vehicle Vehicle2 { get; set; } = null!;
        public PricesPerSize PricesPerSize1{ get; set; } = null!;
        public PricesPerSize PricesPerSize2 { get; set; } = null!;     
        public Driver Driver1 { get; set; } = null!;
        public Driver Driver2 { get; set; } = null!;

        public Delivery Delivery1 { get; set; } = null!;
        public Delivery Delivery2 { get; set; } = null!;
        public Delivery Delivery3 { get; set; } = null!;
        public Delivery Delivery4 { get; set; } = null!;
        public Delivery Delivery5 { get; set; } = null!;

        public FuelPrice FuelPrice1 { get; set; } = null!;
        public FuelPrice FuelPrice2 { get; set; } = null!;

        public CashRegister CashRegister1 { get; set; } = null!;
        public CashRegister CashRegister2 { get; set; } = null!;
        public CashRegister CashRegister3 { get; set; } = null!;
        public CashRegister CashRegister4 { get; set; } = null!;
        public CashRegister CashRegister5 { get; set; } = null!;
        public CashRegister CashRegister6 { get; set; } = null!;

        public Invoice Invoice1 { get; set; } = null!;
        public Invoice Invoice2 { get; set; } = null!;
        public Invoice Invoice3 { get; set; } = null!;
       
        public DeliveryTracking DeliveryTracking1 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking2 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking3 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking4 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking5 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking6 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking7 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking8 { get; set; } = null!;

        public CalendarEvent CalendarEvent1 { get; set; } = null!;
        public CalendarEvent CalendarEvent2 { get; set; } = null!;
        public CalendarEvent CalendarEvent3 { get; set; } = null!;

        public SeedData()
        {
            SeedUsers();
            SeedRoles();
            SeedUserRoles();
            SeedAddresses();
            SeedClientCompanies();
			SeedStandartCargos();
			SeedRequests();
            SeedNonStandartCargos();
            SeedOffers();      
            SeedDrivers();
            SeedVehicles();
			SeedInvoices();
			SeedDeliveries();
            SeedFuelPrices();
            SeedCashRegisters();
            SeedPricesPerSize();
            SeedDeliveryTrackings();
            SeedCalendarEvents();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            ClientCompany1User = new IdentityUser
            {
                UserName = "clientcompany1",
                Email = "clientcompany1@example.com",
                Id = "20450cff-816f-49c8-9546-1c603aec0301", 
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };
            ClientCompany1User.PasswordHash = hasher.HashPassword(ClientCompany1User, "clientcompany1");

            LogiticsCompanyUser = new IdentityUser
            {
                UserName = "logistics",
                Email = "logistics@example.com",
                Id = "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 
                EmailConfirmed = true
            };
            LogiticsCompanyUser.PasswordHash = hasher.HashPassword(LogiticsCompanyUser, "logistics");

            SecretaryUser = new IdentityUser
            {
                UserName = "accountant",
                Email = "secretary@example.com",
                Id = "38ba6810-2800-4ac8-b005-5c27e8248951", 
                EmailConfirmed = true
            };
            SecretaryUser.PasswordHash = hasher.HashPassword(SecretaryUser, "accountant");

            SpeditorUser = new IdentityUser
            {
                UserName = "speditor",
                Email = "speditor@example.com",
                Id = "2e8be95a-186e-403b-b4aa-3874750a3563",
                EmailConfirmed = true
            };
            SpeditorUser.PasswordHash = hasher.HashPassword(SpeditorUser, "speditor");

            DriverUser1 = new IdentityUser
            {
                Id = "driverUser1", 
                UserName = "driver",
                Email = "driver1@example.com",
                PhoneNumber = "1234567893",
                EmailConfirmed = true
            };
            DriverUser1.PasswordHash = hasher.HashPassword(DriverUser1, "driver");
            DriverUser2 = new IdentityUser
            {
                Id = "driverUser2",
                UserName = "driver2@example.com",
                NormalizedUserName = "DRIVER2@EXAMPLE.COM",
                Email = "driver2@example.com",
                PhoneNumber = "0987654321",
                NormalizedEmail = "DRIVER2@EXAMPLE.COM",
                EmailConfirmed = true,
            };
            DriverUser2.PasswordHash = hasher.HashPassword(DriverUser2, "driver2");
        }
        private void SeedRoles()
        {
            ClientCompanyRole = new IdentityRole
            {
                Id = "5d000e64-c056-419a-950f-1992bd1e910d", 
                Name = "ClientCompany",
                NormalizedName = "CLIENTCOMPANY"
            };

            LogisticsCompanyRole = new IdentityRole
            {
                Id = "99027aaa-d346-4dd9-a467-15d74576c080", 
                Name = "LogisticsCompany",
                NormalizedName = "LOGISTICSCOMPANY"
            };

            AccountRole = new IdentityRole
            {
                Id = "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", 
                Name = "Accountant",
                NormalizedName = "ACCOUNTANT"
            };

            SpeditorRole = new IdentityRole
            {
                Id = "27609f35-fbc8-4dc4-9d12-7ff2dd400327", 
                Name = "Speditor",
                NormalizedName = "SPEDITOR"
            };

            DriverRole = new IdentityRole
            {
                Id = "350868c0-bf0f-4f70-b4c9-155351bc6429",
                Name = "Driver",
                NormalizedName = "DRIVER"
            };
        }
        private void SeedUserRoles()
        {
            ClientCompanyUserRole = new IdentityUserRole<string>
            {
                UserId = "20450cff-816f-49c8-9546-1c603aec0301", 
                RoleId = "5d000e64-c056-419a-950f-1992bd1e910d" 
            };

            LogisticsCompanyUserRole = new IdentityUserRole<string>
            {
                UserId = "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 
                RoleId = "99027aaa-d346-4dd9-a467-15d74576c080"  
            };

            AccountantUserRole = new IdentityUserRole<string>
            {
                UserId = "38ba6810-2800-4ac8-b005-5c27e8248951", 
                RoleId = "20ddc22c-ca6d-4feb-a688-0f31a430b5eb" 
            };

            SpeditorUserRole = new IdentityUserRole<string>
            {
                UserId = "2e8be95a-186e-403b-b4aa-3874750a3563", 
                RoleId = "27609f35-fbc8-4dc4-9d12-7ff2dd400327"  
            };

            Driver1UserRole = new IdentityUserRole<string>
            {
                UserId = DriverUser1.Id,
                RoleId = DriverRole.Id
            };
            Driver2UserRole = new IdentityUserRole<string>
            {
                UserId = DriverUser2.Id,
                RoleId = DriverRole.Id
            };
        }
        private void SeedAddresses()
        {
            Address1 = new Address { Id = 1, Street = "123 Main St", County = "Central", City = "Metropolis", PostalCode = "10001" };
            Address2 = new Address { Id = 2, Street = "456 Side St", County = "Westside", City = "Gotham", PostalCode = "10002", Latitude = 40.7128, Longitude = -74.0060 };
            Address3 = new Address { Id = 3, Street = "789 Elm St", County = "Northside", City = "Star City", PostalCode = "10003", Latitude = 37.7749, Longitude = -122.4194 };
            Address4 = new Address { Id = 4, Street = "101 Pine St", County = "Eastville", City = "Central City", PostalCode = "10004", Latitude = 39.9526, Longitude = -75.1652 };
            Address5 = new Address { Id = 5, Street = "202 Maple St", County = "Southend", City = "Smallville", PostalCode = "10005", Latitude = 38.0293, Longitude = -78.4767 };
            Address6 = new Address { Id = 6, Street = "303 Oak St", County = "Old Town", City = "Bludhaven", PostalCode = "10006", Latitude = 36.8508, Longitude = -76.2859 };
            Address7 = new Address { Id = 7, Street = "404 Birch St", County = "Downtown", City = "Coast City", PostalCode = "10007", Latitude = 34.0522, Longitude = -118.2437 };
            Address8 = new Address { Id = 8, Street = "505 Cedar St", County = "West End", City = "National City", PostalCode = "10008", Latitude = 32.7157, Longitude = -117.1611 };
            Address9 = new Address { Id = 9, Street = "606 Cherry St", County = "Upper Hill", City = "Ivy Town", PostalCode = "10009", Latitude = 40.7580, Longitude = -111.8762 };
            Address10 = new Address { Id = 10, Street = "707 Aspen St", County = "Harborview", City = "Gateway City", PostalCode = "10010", Latitude = 47.6062, Longitude = -122.3321 };
            Address11 = new Address { Id = 11, Street = "808 Willow St", County = "Lakeside", City = "Opal City", PostalCode = "10011", Latitude = 35.2271, Longitude = -80.8431 };
            Address12 = new Address { Id = 12, Street = "909 Fir St", County = "Midtown", City = "Fawcett City", PostalCode = "10012", Latitude = 33.7490, Longitude = -84.3880 };
        }
        private void SeedClientCompanies()
        {
            ClientCompany1 = new ClientCompany
            {
                Id = 1,
                Name = "Client Company 1",
                UserId = ClientCompany1User.Id,
                RegistrationStatus = "Approved",
                ContactPerson = "John Doe",
                AlternativePhoneNumber = "1234567891",
                RegistrationNumber = "REG123456",
                Industry = "Manufacturing",
                AddressId = 1,
                CreatedAt = DateTime.Now.AddDays(-200),
            };
        }
		private void SeedStandartCargos()
		{
			StandartCargo1 = new StandartCargo
			{
				Id = 1,
				TypeOfPallet = "Euro",
				NumberOfPallets = 5,
				PalletLength = 120,
				PalletWidth = 80,
				PalletHeight = 100,
				PalletVolume = 0.96,
				WeightOfPallets = 500,
				PalletsAreStackable = true
			};

			StandartCargo2 = new StandartCargo
			{
				Id = 2,
				TypeOfPallet = "Industrial",
				NumberOfPallets = 3,
				PalletLength = 130,
				PalletWidth = 90,
				PalletHeight = 110,
				PalletVolume = 1.29,
				WeightOfPallets = 700,
				PalletsAreStackable = false
			};

			StandartCargo3 = new StandartCargo
			{
				Id = 3,
				TypeOfPallet = "Standard",
				NumberOfPallets = 4,
				PalletLength = 120,
				PalletWidth = 80,
				PalletHeight = 100,
				PalletVolume = 0.96,
				WeightOfPallets = 450,
				PalletsAreStackable = true
			};
		}
		private void SeedRequests()
        {          
            Request1 = new Request
            {
                Id = 1,
                RerefenceNumber = "R0001",
				ClientCompanyId = ClientCompany1.Id,
				CargoType = "Standard",
                TypeOfGoods = "Electronics",
                Type = "Domestic",
                PickupAddressId = 3,              
                DeliveryAddressId = 4,
                SharedTruck = false,
                ApproximatePrice = 500,
                CalculatedPrice = 450,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                Status = "Approved",
                SpecialInstructions = "Handle with care",
                IsRefrigerated = false,
                CreatedAt = DateTime.Now.AddDays(-20),
                StandartCargoId = StandartCargo1.Id,
                TotalWeight = 300,
                TotalVolume = 12,
                Kilometers = 500
            };

			Request2 = new Request
			{
				Id = 2,
				ClientCompanyId = ClientCompany1.Id,
				RerefenceNumber = "R0002",
				CargoType = "Standard",
				TypeOfGoods = "Furniture",
				Type = "International",
				PickupAddressId = 5,
				DeliveryAddressId = 6,
				SharedTruck = true,
				ApproximatePrice = 1200,
				CalculatedPrice = 1150,
				ExpectedDeliveryDate = DateTime.Now.AddDays(10),
				Status = "Approved",
				SpecialInstructions = "Keep dry",
				IsRefrigerated = false,
				CreatedAt = DateTime.Now.AddDays(-21),
				StandartCargoId = StandartCargo2.Id,
				TotalWeight = 500,
				TotalVolume = 20,
				Kilometers = 1000
			};

			Request3 = new Request
			{
				Id = 3,
				ClientCompanyId = ClientCompany1.Id,
				RerefenceNumber = "R0003",
				CargoType = "Non-Standard",
				TypeOfGoods = "Machinery",
				Type = "Domestic",
				PickupAddressId = 7,
				DeliveryAddressId = 8,
				SharedTruck = false,
				ApproximatePrice = 2000,
				CalculatedPrice = 1900,
				ExpectedDeliveryDate = DateTime.Now.AddDays(5),
				Status = "Approved",
				SpecialInstructions = "Requires crane",
				IsRefrigerated = false,
                StandartCargoId = default,
				CreatedAt = DateTime.Now.AddDays(-22),
				TotalWeight = 2000,
				TotalVolume = 50,
				Kilometers = 2000
			};

			Request4 = new Request
			{
				Id = 4,
                StandartCargoId = StandartCargo3.Id,
				RerefenceNumber = "R0004",
				ClientCompanyId = 1,
				CargoType = "Standard",
				TypeOfGoods = "Textiles",
				Type = "Domestic",
				PickupAddressId = 9,
				DeliveryAddressId = 10,
				SharedTruck = true,
				ApproximatePrice = 350,
				CalculatedPrice = 340,
				ExpectedDeliveryDate = DateTime.Now.AddDays(-3),
				Status = "Approved",
				SpecialInstructions = "Do not compress",
				IsRefrigerated = false,
				CreatedAt = DateTime.Now.AddDays(-23),
				TotalWeight = 150,
				TotalVolume = 8,
				Kilometers = 500
			};

			Request5 = new Request
			{
				Id = 5,
				RerefenceNumber = "R0005",
				ClientCompanyId = 1,
				CargoType = "Non Standard",
				TypeOfGoods = "Books",
				Type = "International",
				PickupAddressId = 11,
				DeliveryAddressId = 12,
				SharedTruck = false,
				ApproximatePrice = 220,
				CalculatedPrice = 210,
				ExpectedDeliveryDate = DateTime.Now.AddDays(-5),
				Status = "Approved",
				SpecialInstructions = "Fragile binding",
				IsRefrigerated = false,
				CreatedAt = DateTime.Now.AddDays(-24),
				StandartCargoId = default,
				TotalWeight = 300,
				TotalVolume = 1.8,
				Kilometers = 1000
			};
		}      
        private void SeedNonStandartCargos()
        {
            NonStandardCargo1 = new NonStandardCargo
            { 
                Id = 1,
                Length = 120,
                Width = 100,
                Height = 150,
                Volume = 1.8,
                Weight = 300,
                Description = "Large industrial machine",
                RequestId = Request3.Id
            };

            NonStandardCargo2 = new NonStandardCargo
            {
                Id = 2,
                Length = 90,
                Width = 75,
                Height = 80,
                Volume = 0.6,
                Weight = 120,
                Description = "Auxiliary machine part",
                RequestId = Request3.Id
            };

            NonStandardCargo3 = new NonStandardCargo
            {
                Id = 3,
                Length = 150,
                Width = 80,
                Height = 100,
                Volume = 1.2,
                Weight = 450,
                Description = "High-pressure pump",
                RequestId = Request3.Id
            };

            NonStandardCargo4 = new NonStandardCargo
            {
                Id = 4,
                RequestId = Request5.Id,  
                Length = 150,            
                Width = 120,              
                Height = 100,             
                Volume = 1.8,             
                Weight = 300,             
                Description = "Extra non-standard cargo for Request5"
            };
        }
        private void SeedOffers()
        {
            Offer1 = new Offer
            {
                Id = 1,
                RequestId = 1, 
                FinalPrice = 1200.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-15),
                OfferNumber = "OFFER0001",
            };
            Offer2 = new Offer
            {
                Id = 2,
                RequestId = 2, 
                FinalPrice = 1500.0m,
                OfferStatus = "Approved",
                OfferNumber = "OFFER0002",
                OfferDate = DateTime.Now.AddDays(-16),
            };
            Offer3 = new Offer
            {
                Id = 3,
                RequestId = 3,
                FinalPrice = 1800.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-15),
                OfferNumber = "OFFER0003",
                DeliveryId = null
            };
            Offer4 = new Offer
            {
                Id = 4,
                RequestId = 4, 
                FinalPrice = 2100.0m,
                OfferNumber = "OFFER0004",
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-12),
            };
            Offer5 = new Offer
            {
                Id = 5,
                RequestId = 5,
                OfferNumber = "OFFER0005",
                FinalPrice = 2300.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-13),
            };
        }
        private void SeedDrivers()
        {
            Driver1 = new Driver
            {
                Id = 1,
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
            Driver2 = new Driver
            {
                Id = 2,
                Name = "Jane Smith",
                LicenseNumber = "D87654321",
                LicenseExpiryDate = DateTime.Now.AddYears(1),
                UserId = "driverUser2",
                Salary = 3200.0m,
                Age = 28,
                YearOfExperience = 4,
                MonthsOfExperience = 8,
                IsAvailable = false,
                Preferrences = "Prefers city deliveries"
            };
        }
        private void SeedVehicles()
        {
            Vehicle1 = new Vehicle
            {
                Id = 1,
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
            Vehicle2 = new Vehicle
            {
                Id = 2,
                EmissionFactor = 2.63,
                RegistrationNumber = "XYZ789",
                VehicleType = "Van",
                Length = 6.0,
                Width = 2.0,
                Height = 2.5,
                Volume = 30.0,
                EuroPalletCapacity = 10,
                IndustrialPalletCapacity = 8,
                ArePalletsStackable = false,
                MaxWeightCapacity = 3500,
                FuelConsumptionPer100Km = 8.0,
                VehicleStatus = "Available",
                LastYearMaintenance = DateTime.Now.AddMonths(-1),
                KilometersDriven = 90000,
                KilometersLeftToChangeParts = 30000,
                PurchasePrice = 25000.0m,
                ContantsExpenses = 2000.0m
            };
        }
		private void SeedInvoices()
		{
			Invoice1 = new Invoice
			{
				Id = 1,
				PaidOnTime = true,
				PaidDate = DateTime.Now.AddDays(-5),
				InvoiceNumber = "INV001",
				InvoiceDate = DateTime.Now.AddDays(-10),
				Description = "Invoice for Delivery 1",
				FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq",
				Status = "Paid",
				IsPaid = true
			};

			Invoice2 = new Invoice
			{
				Id = 2,
				InvoiceNumber = "INV004",
				PaidOnTime = false,
				FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq",
				InvoiceDate = DateTime.Now.AddDays(-7),
				Description = "Invoice for Delivery 4",
				Status = "Paid",
				IsPaid = false
			};
			Invoice3 = new Invoice
			{
				Id = 3,
				PaidOnTime = false,
				InvoiceNumber = "INV005",
				InvoiceDate = DateTime.Now.AddDays(-6),
				FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq",
				Description = "Invoice for Delivery 5",
				Status = "Overdue",
				IsPaid = true
			};
		}
		private void SeedDeliveries()
         {
            Delivery1 = new Delivery
            {
                Id = 1,
                CarbonEmission = 38.7,
                InvoiceId = Invoice1.Id,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 1,
                Status = "Delivered",
                TotalExpenses = 500.00m,
                Profit = 750.00m,
                ReferenceNumber = "DEL0001",
                DeliveryStep = 2,
                ActualDeliveryDate = DateTime.Now.AddDays(7)
            };
            Delivery2 = new Delivery
            {
                Id = 2,
                CarbonEmission = 40.0,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 2,
                Status = "Booked",
                TotalExpenses = 450.00m,
                Profit = 700.00m,
                ReferenceNumber = "DEL0002",
                DeliveryStep = 1,
                ActualDeliveryDate = DateTime.Now.AddDays(-2)
            };
            Delivery3 = new Delivery
            {
                Id = 3,
                CarbonEmission = 35.0,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 3,
                Status = "Delivered",
                TotalExpenses = 600.00m,
                Profit = 800.00m,
                ReferenceNumber = "DEL0003",
                DeliveryStep = 4,
                ActualDeliveryDate = DateTime.Now.AddDays(-3)
            };
            Delivery4 = new Delivery
            {
                Id = 4,
                VehicleId = 1,
                CarbonEmission = 45.0,
                DriverId = 1,
                OfferId = 4,
                Status = "In Transit",
                TotalExpenses = 520.00m,
                Profit = 780.00m,
                ReferenceNumber = "DEL0004",
                DeliveryStep = 2,
                InvoiceId = Invoice3.Id,
                ActualDeliveryDate = DateTime.Now.AddDays(-4)
            };
            Delivery5 = new Delivery
            {
                Id = 5,
                VehicleId = 1,
                InvoiceId = Invoice2.Id,
                CarbonEmission = 50.0,
                DriverId = 1,
                OfferId = 5,
                Status = "Booked",
                TotalExpenses = 480.00m,
                Profit = 720.00m,
                ReferenceNumber = "DEL0005",
                DeliveryStep = 3,
                ActualDeliveryDate = DateTime.Now.AddDays(-5)
            };
         }     
        private void SeedCashRegisters()
         {
            CashRegister1 = new CashRegister
            {
                Id = 1,
                DeliveryId = 1,
                Description = "Fuel Expense",
                Type = "Vehicle Expenses",
                Amount = 100.00m,
                DateSubmitted = DateTime.Now.AddDays(8),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            CashRegister2 = new CashRegister
            {
                Id = 2,
                DeliveryId = 1,
                Description = "Toll Fee",
                Type = "Vehicle Expenses",
                Amount = 50.00m,
                DateSubmitted = DateTime.Now.AddDays(8),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            CashRegister3 = new CashRegister
            {
                Id = 3,
                DeliveryId = 2,
                Description = "Driver Lunch",
                Type = "Driver Expenses",
                Amount = 20.00m,
                DateSubmitted = DateTime.Now.AddDays(-3),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"

            };
            CashRegister4 = new CashRegister
            {
                Id = 4,
                DeliveryId = 3,
                Description = "Repair Costs",
                Type = "Vehicle Expenses",
                Amount = 150.00m,
                DateSubmitted = DateTime.Now.AddDays(-2),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            CashRegister5 = new CashRegister
            {
                Id = 5,
                DeliveryId = 4,
                Description = "Accommodation",
                Type = "Driver Expenses",
                Amount = 80.00m,
                DateSubmitted = DateTime.Now.AddDays(-1),
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
            CashRegister6 = new CashRegister
            {
                Id = 6,
                DeliveryId = 5,
                Description = "Miscellaneous",
                Type = "Other Expenses",
                Amount = 40.00m,
                DateSubmitted = DateTime.Now,
                FileId = "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq"
            };
         }
        public void SeedPricesPerSize()
        {
            PricesPerSize1 = new PricesPerSize
            {
                Id = 1,
                VehicleId = Vehicle1.Id, 
                QuotientForDomesticNotSharedTruck = 1.2,
                QuotientForDomesticSharedTruck = 0.9,
                QuotientForInternationalNotSharedTruck = 1.5,
                QuotientForInternationalSharedTruck = 1.1,
            };
            PricesPerSize2 = new PricesPerSize
            {
                Id = 2,
                VehicleId = Vehicle2.Id,
                QuotientForDomesticNotSharedTruck = 1.3,
                QuotientForDomesticSharedTruck = 0.85,
                QuotientForInternationalNotSharedTruck = 1.6,
                QuotientForInternationalSharedTruck = 1.2,
            };
        }
        private void SeedFuelPrices()
        {
            FuelPrice1 = new FuelPrice
            {
                Id = 1,
                Price = 2.50m,
                Date = DateTime.Now.AddDays(-3)
            };
            FuelPrice2 = new FuelPrice
            {
                Id = 2,
                Price = 2.60m,
                Date = DateTime.Now.AddDays(-2)
            };
        }
        public void SeedDeliveryTrackings()
        {
            DeliveryTracking1 = new DeliveryTracking
            {
                Id = 1,
                DeliveryId = 1,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Delivery completed successfully.",
                Timestamp = DateTime.Now.AddDays(7),
                Latitude = 42.6977, 
                Longitude = 23.3219,
                Address = "Sofia, Bulgaria"
            };
            DeliveryTracking6 = new DeliveryTracking
            {
                Id = 6,
                DeliveryId = 1,
                DriverId = 1,
                StatusUpdate = "In Transit",
                Notes = "Delivery in transit.",
                Timestamp = DateTime.Now.AddDays(7),
                Latitude = 42.6977,
                Longitude = 23.3219,
                Address = "Sliven, Bulgaria"
            };
            DeliveryTracking7 = new DeliveryTracking
            {
                Id = 7,
                DeliveryId = 1,
                DriverId = 1,
                StatusUpdate = "Collected",
                Notes = "Collected cargo.",
                Timestamp = DateTime.Now.AddDays(7),
                Latitude = 42.6977,
                Longitude = 23.3219,
                Address = "Sliven, Bulgaria"
            };
            DeliveryTracking2 = new DeliveryTracking
            {
                Id = 2,
                DeliveryId = 2,
                DriverId = 1,
                StatusUpdate = "Booked",
                Notes = "Delivery scheduled.",
                Timestamp = DateTime.Now.AddDays(-4),
                Latitude = 43.2141,
                Longitude = 27.9147,
                Address = "Varna, Bulgaria"
            };
            DeliveryTracking3 = new DeliveryTracking
            {
                Id = 3,
                DeliveryId = 3,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Delivered on time.",
                Timestamp = DateTime.Now.AddDays(-3),
                Latitude = 42.1354,
                Longitude = 24.7453,
                Address = "Plovdiv, Bulgaria"
            };
            DeliveryTracking4 = new DeliveryTracking
            {
                Id = 4,
                DeliveryId = 4,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Awaiting driver assignment.",
                Timestamp = DateTime.Now.AddDays(-2),
                Latitude = 41.6321,
                Longitude = 25.3790,
                Address = "Kardzhali, Bulgaria"
            };
            DeliveryTracking5 = new DeliveryTracking
            {
                Id = 5,
                DeliveryId = 5,
                DriverId = 1,
                StatusUpdate = "Booked",
                Notes = "Package left with neighbor.",
                Timestamp = DateTime.Now.AddDays(-1),
                Latitude = 42.5048,
                Longitude = 27.4626,
                Address = "Burgas, Bulgaria"
            };
        }
        private void SeedCalendarEvents()
        {
            var now = DateTime.UtcNow;

            CalendarEvent1 = new CalendarEvent
            {
                Id = 1,
                Title = "Monthly Payment Due",
                Date = DateTime.Now.AddMonths(-1),
                EventType = "Paid",
                UserId = ClientCompany1User.Id
            };
            CalendarEvent2 = new CalendarEvent
            {
                Id = 2,
                Title = "Quarterly Review",
                Date = DateTime.Now.AddMonths(-3),
                EventType = "Paid",
                UserId = ClientCompany1User.Id
            };
            CalendarEvent3 = new CalendarEvent
            {
                Id = 3,
                Title = "Annual Delivery Milestone",
                Date = DateTime.Now.AddMonths(-6),
                EventType = "Delivered",
                UserId = ClientCompany1User.Id
            };
        }
    }
}
