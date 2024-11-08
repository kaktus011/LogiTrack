using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class InitialMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryLatitude",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryLongitude",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PickupAddress",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PickupLatitude",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PickupLongitude",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ClientCompanies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ClientCompanies");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ClientCompanies");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "ClientCompanies");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddressId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Delivery address identifier");

            migrationBuilder.AddColumn<int>(
                name: "PickupAddressId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Pickup address identifier");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ClientCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Address of the company identifier");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Street name and number"),
                    County = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "County or region"),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "City name"),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Company's postal code"),
                    Latitude = table.Column<double>(type: "float", nullable: true, comment: "Latitude of the address"),
                    Longitude = table.Column<double>(type: "float", nullable: true, comment: "Longitude of the address")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                },
                comment: "Address Entity");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "County", "Latitude", "Longitude", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Metropolis", "Central", null, null, "10001", "123 Main St" },
                    { 2, "Gotham", "Westside", null, null, "10002", "456 Side St" },
                    { 3, "Star City", "Northside", null, null, null, "789 Elm St" },
                    { 4, "Central City", "Eastville", null, null, null, "101 Pine St" },
                    { 5, "Smallville", "Southend", null, null, null, "202 Maple St" },
                    { 6, "Bludhaven", "Old Town", null, null, null, "303 Oak St" },
                    { 7, "Coast City", "Downtown", null, null, null, "404 Birch St" },
                    { 8, "National City", "West End", null, null, null, "505 Cedar St" },
                    { 9, "Ivy Town", "Upper Hill", null, null, null, "606 Cherry St" },
                    { 10, "Gateway City", "Harborview", null, null, null, "707 Aspen St" },
                    { 11, "Opal City", "Lakeside", null, null, null, "808 Willow St" },
                    { 12, "Fawcett City", "Midtown", null, null, null, "909 Fir St" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "ae2d7700-9d1d-4668-9f20-308844f22c17", "Accountant", "ACCOUNTANT" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "669108c9-deb5-41c9-9db3-3cf27c8c2231", "Speditor", "SPEDITOR" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "3ed5c6a7-d3d4-49f1-bceb-96b66b1dab6a", "Driver", "DRIVER" },
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "65d8677d-bf43-4005-bda7-1c2c72687524", "ClientCompany", "CLIENTCOMPANY" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "c0c204ed-23bc-4d9e-afca-5f0c145d5c09", "LogisticsCompany", "LOGISTICSCOMPANY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20450cff-816f-49c8-9546-1c603aec0301", 0, "7ece6412-1d19-4ff4-9139-b616cdcc5c24", "clientcompany1@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBOYNSBDA5VPw91CkTjPMFd6N5qbUwtVJZbvhhxk6oVzpcXbFpE5fBWqYLg+O4Qz/A==", "1234567890", false, "e16c1e9b-e772-40ee-a21b-d519f2e16b80", false, "clientcompany1" },
                    { "2e8be95a-186e-403b-b4aa-3874750a3563", 0, "c1df6e91-f956-4d56-aa2f-a2fbcf29278d", "speditor@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEIGZnzqY0nUUMEXMWyUsZqXpylxOTRZ4gBJltmfw2+g+zx3nq/ZSMhWe2zuZY80h7w==", null, false, "744f8464-41a9-411d-832f-0e51bad23e1b", false, "speditor" },
                    { "38ba6810-2800-4ac8-b005-5c27e8248951", 0, "107ff2c4-d5c2-4786-bc55-ba417292ff6d", "secretary@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEKfYIbSXrr0v0+BEYlZdKRtHSwPf3vi7OHJttNALTOGM7OarvMyJU8WYCULAcM86nQ==", null, false, "5e68ab67-7432-4abe-926f-a653b2f2eb3a", false, "secretary" },
                    { "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 0, "d4d84be8-06bc-4691-9b57-b7ccdfe08580", "logistics@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEPIUKUnmztFjoIvo22ot2aqM8pIvBMq07LTO6lRRiptztRWso8togLr1S/jnBcl8WQ==", null, false, "600cee84-dfff-4999-bebd-55889ca57cfa", false, "logistics" },
                    { "driverUser1", 0, "80139155-3b5e-4249-94d0-c32732f70686", "driver1@example.com", true, false, null, "DRIVER1@EXAMPLE.COM", "DRIVER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAECXz+4cTl9tLh/OZDjGHyWLd3boJu0IZgCWo2onYlWko0WvipkxH+qtkcySA1zvA4w==", null, false, "6273d7b8-e12b-4c90-bfab-45c64a555599", false, "driver1@example.com" },
                    { "driverUser2", 0, "44582ea8-7cc5-4598-a9c4-82bbc7497f35", "driver2@example.com", true, false, null, "DRIVER2@EXAMPLE.COM", "DRIVER2@EXAMPLE.COM", null, null, false, "89388fa1-1ca8-4208-8260-cc4866133e9b", false, "driver2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "Date", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 3, 20, 3, 26, 797, DateTimeKind.Local).AddTicks(9910), 2.50m },
                    { 2, new DateTime(2024, 11, 4, 20, 3, 26, 797, DateTimeKind.Local).AddTicks(9912), 2.60m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "ContantsExpenses", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "KilometersDriven", "KilometersLeftToChangeParts", "LastYearMaintenance", "Length", "MaxWeightCapacity", "PurchasePrice", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 5000.0m, 33, 12.5, 2.7999999999999998, 20, 150000.0, 50000.0, new DateTime(2024, 8, 6, 20, 3, 26, 779, DateTimeKind.Local).AddTicks(1741), 12.0, 18000.0, 75000.0m, "ABC123", "Available", "Truck", 84.0, 2.5 },
                    { 2, false, 2000.0m, 10, 8.0, 2.5, 8, 90000.0, 30000.0, new DateTime(2024, 10, 6, 20, 3, 26, 779, DateTimeKind.Local).AddTicks(1746), 6.0, 3500.0, 25000.0m, "XYZ789", "Available", "Van", 30.0, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "2e8be95a-186e-403b-b4aa-3874750a3563" },
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "38ba6810-2800-4ac8-b005-5c27e8248951" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "6bab54d5-5a88-4128-92d2-4d12ad0baa32" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser1" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser2" }
                });

            migrationBuilder.InsertData(
                table: "ClientCompanies",
                columns: new[] { "Id", "AddressId", "AlternativePhoneNumber", "ContactPerson", "CreatedAt", "Industry", "Name", "RegistrationNumber", "RegistrationStatus", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "1234567891", "John Doe", new DateTime(2024, 10, 17, 20, 3, 25, 154, DateTimeKind.Local).AddTicks(3726), "Manufacturing", "Client Company 1", "REG123456", "Approved", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { 2, 2, "9876543210", "Jane Smith", new DateTime(2024, 10, 27, 20, 3, 25, 154, DateTimeKind.Local).AddTicks(3747), "Fashion", "Client Company 2", "REG654321", "Pending", null }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, 30, true, new DateTime(2025, 11, 6, 20, 3, 25, 804, DateTimeKind.Local).AddTicks(3711), "D12345678", 6, "John Doe", "No night shifts", 3000.0m, "driverUser1", 5 },
                    { 2, 28, false, new DateTime(2025, 11, 6, 20, 3, 25, 804, DateTimeKind.Local).AddTicks(3718), "D87654321", 8, "Jane Smith", "Prefers city deliveries", 3200.0m, "driverUser2", 4 }
                });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1000.0m, 800.0m, 1500.0m, 1200.0m, 1.2, 0.90000000000000002, 1.5, 1.1000000000000001, 1 },
                    { 2, 1100.0m, 850.0m, 1600.0m, 1300.0m, 1.3, 0.84999999999999998, 1.6000000000000001, 1.2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "Id", "ClientCompanyId", "Date", "EventType", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 6, 20, 3, 26, 804, DateTimeKind.Local).AddTicks(3179), "Paid", "Monthly Payment Due" },
                    { 2, 1, new DateTime(2024, 8, 6, 20, 3, 26, 804, DateTimeKind.Local).AddTicks(3181), "Paid", "Quarterly Review" },
                    { 3, 1, new DateTime(2024, 5, 6, 20, 3, 26, 804, DateTimeKind.Local).AddTicks(3183), "Delivered", "Annual Delivery Milestone" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryAddressId", "ExpectedDeliveryDate", "IsRefrigerated", "Kilometers", "NumberOfNonStandartGoods", "OfferId", "PickupAddressId", "SharedTruck", "SpecialInstructions", "StandartCargoId", "Status", "TotalVolume", "TotalWeight", "Type", "TypeOfGoods" },
                values: new object[,]
                {
                    { 1, 500m, 450m, "Standard", 1, new DateTime(2024, 11, 6, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4022), 4, new DateTime(2024, 11, 13, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4019), false, 500.0, null, null, 3, false, "Handle with care", 0, "Pending", 12.0, 300.0, "Domestic", "Electronics" },
                    { 2, 1200m, 1150m, "Standard", 1, new DateTime(2024, 11, 6, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4029), 6, new DateTime(2024, 11, 16, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4027), false, 1000.0, null, null, 5, true, "Keep dry", 0, "Accepted", 20.0, 500.0, "International", "Furniture" },
                    { 3, 2000m, 1900m, "Non-Standard", 1, new DateTime(2024, 11, 6, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4039), 8, new DateTime(2024, 11, 21, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4036), false, 2000.0, null, null, 7, false, "Requires crane", 0, "Pending", 50.0, 2000.0, "Domestic", "Machinery" },
                    { 4, 350m, 340m, "Standard", 1, new DateTime(2024, 11, 6, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4050), 10, new DateTime(2024, 11, 9, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4047), false, 500.0, null, null, 9, true, "Do not compress", 0, "Pending", 8.0, 150.0, "Domestic", "Textiles" },
                    { 5, 220m, 210m, "Standard", 1, new DateTime(2024, 11, 6, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4057), 12, new DateTime(2024, 11, 10, 20, 3, 25, 782, DateTimeKind.Local).AddTicks(4055), false, 1000.0, null, null, 11, false, "Fragile binding", 0, "Pending", 1.8, 300.0, "International", "Books" }
                });

            migrationBuilder.InsertData(
                table: "NonStandardCargos",
                columns: new[] { "Id", "Description", "Height", "Length", "RequestId", "Volume", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, "Large industrial machine", 150.0, 120.0, 3, 1.8, 300.0, 100.0 },
                    { 2, "Auxiliary machine part", 80.0, 90.0, 3, 0.59999999999999998, 120.0, 75.0 },
                    { 3, "High-pressure pump", 100.0, 150.0, 3, 1.2, 450.0, 80.0 },
                    { 4, "Extra non-standard cargo for Request5", 100.0, 150.0, 5, 1.8, 300.0, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "Notes", "OfferDate", "OfferStatus", "RequestId" },
                values: new object[,]
                {
                    { 1, null, null, 1200.0m, "Initial offer for Request 1", new DateTime(2024, 10, 27, 20, 3, 25, 168, DateTimeKind.Local).AddTicks(7272), "Pending", 1 },
                    { 2, null, null, 1500.0m, "Offer accepted for Request 2", new DateTime(2024, 10, 29, 20, 3, 25, 168, DateTimeKind.Local).AddTicks(7274), "Approved", 2 },
                    { 3, null, null, 1800.0m, "Offer approved for Request 3", new DateTime(2024, 11, 1, 20, 3, 25, 168, DateTimeKind.Local).AddTicks(7276), "Approved", 3 },
                    { 4, null, null, 2100.0m, "Approved offer for Request 4", new DateTime(2024, 11, 4, 20, 3, 25, 168, DateTimeKind.Local).AddTicks(7278), "Approved", 4 },
                    { 5, null, null, 2300.0m, "Finalized offer for Request 5", new DateTime(2024, 11, 6, 20, 3, 25, 168, DateTimeKind.Local).AddTicks(7280), "Accepted", 5 }
                });

            migrationBuilder.InsertData(
                table: "StandartCargos",
                columns: new[] { "Id", "NumberOfPallets", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "RequestId", "TypeOfPallet", "WeightOfPallets" },
                values: new object[,]
                {
                    { 1, 5, 100.0, 120.0, 0.95999999999999996, 80.0, true, 1, "Euro", 500.0 },
                    { 2, 3, 110.0, 130.0, 1.29, 90.0, false, 2, "Industrial", 700.0 },
                    { 3, 4, 100.0, 120.0, 0.95999999999999996, 80.0, true, 4, "Standard", 450.0 }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "ActualDeliveryDate", "DeliveryStep", "DriverId", "InvoiceId", "OfferId", "Profit", "ReferenceNumber", "Status", "TotalExpenses", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 5, 20, 3, 26, 771, DateTimeKind.Local).AddTicks(7425), 2, 1, null, 1, 750.00m, "DEL0001", "In Transit", 500.00m, 1 },
                    { 2, new DateTime(2024, 11, 4, 20, 3, 26, 771, DateTimeKind.Local).AddTicks(7431), 1, 1, null, 2, 700.00m, "DEL0002", "Booked", 450.00m, 1 },
                    { 3, new DateTime(2024, 11, 3, 20, 3, 26, 771, DateTimeKind.Local).AddTicks(7434), 4, 1, null, 3, 800.00m, "DEL0003", "Delivered", 600.00m, 1 },
                    { 4, new DateTime(2024, 11, 2, 20, 3, 26, 771, DateTimeKind.Local).AddTicks(7473), 2, 1, null, 4, 780.00m, "DEL0004", "In Transit", 520.00m, 1 },
                    { 5, new DateTime(2024, 11, 1, 20, 3, 26, 771, DateTimeKind.Local).AddTicks(7476), 3, 1, null, 5, 720.00m, "DEL0005", "Booked", 480.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[,]
                {
                    { 1, 100.00m, new DateTime(2024, 11, 1, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6734), 1, "Fuel Expense", "", "Vehicle Expenses" },
                    { 2, 50.00m, new DateTime(2024, 11, 2, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6736), 1, "Toll Fee", "", "Vehicle Expenses" },
                    { 3, 20.00m, new DateTime(2024, 11, 3, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6738), 2, "Driver Lunch", "", "Driver Expenses" },
                    { 4, 150.00m, new DateTime(2024, 11, 4, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6740), 3, "Repair Costs", "", "Vehicle Expenses" },
                    { 5, 80.00m, new DateTime(2024, 11, 5, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6742), 4, "Accommodation", "", "Driver Expenses" },
                    { 6, 40.00m, new DateTime(2024, 11, 6, 20, 3, 25, 147, DateTimeKind.Local).AddTicks(6744), 5, "Miscellaneous", "", "Other Expenses" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTrackings",
                columns: new[] { "Id", "Address", "DeliveryId", "DriverId", "Latitude", "Longitude", "Notes", "StatusUpdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Sofia, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Delivery completed successfully.", "Delivered", new DateTime(2024, 11, 1, 20, 3, 26, 785, DateTimeKind.Local).AddTicks(3262) },
                    { 2, "Varna, Bulgaria", 2, 1, 43.214100000000002, 27.9147, "Delivery scheduled.", "Booked", new DateTime(2024, 11, 2, 20, 3, 26, 785, DateTimeKind.Local).AddTicks(3291) },
                    { 3, "Plovdiv, Bulgaria", 3, 1, 42.135399999999997, 24.7453, "Delivered on time.", "Delivered", new DateTime(2024, 11, 3, 20, 3, 26, 785, DateTimeKind.Local).AddTicks(3293) },
                    { 4, "Kardzhali, Bulgaria", 4, 1, 41.632100000000001, 25.379000000000001, "Awaiting driver assignment.", "Delivered", new DateTime(2024, 11, 4, 20, 3, 26, 785, DateTimeKind.Local).AddTicks(3295) },
                    { 5, "Burgas, Bulgaria", 5, 1, 42.504800000000003, 27.462599999999998, "Package left with neighbor.", "Booked", new DateTime(2024, 11, 5, 20, 3, 26, 785, DateTimeKind.Local).AddTicks(3297) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "Description", "FileId", "InvoiceDate", "InvoiceNumber", "IsPaid" },
                values: new object[,]
                {
                    { 1, null, 1, "Invoice for Delivery 1", "", new DateTime(2024, 10, 27, 20, 3, 25, 162, DateTimeKind.Local).AddTicks(3055), "INV001", true },
                    { 2, null, 2, "Invoice for Delivery 2", "", new DateTime(2024, 10, 28, 20, 3, 25, 162, DateTimeKind.Local).AddTicks(3057), "INV002", false },
                    { 3, null, 3, "Invoice for Delivery 3", "", new DateTime(2024, 10, 29, 20, 3, 25, 162, DateTimeKind.Local).AddTicks(3059), "INV003", true },
                    { 4, null, 4, "Invoice for Delivery 4", "", new DateTime(2024, 10, 30, 20, 3, 25, 162, DateTimeKind.Local).AddTicks(3061), "INV004", false },
                    { 5, null, 5, "Invoice for Delivery 5", "", new DateTime(2024, 10, 31, 20, 3, 25, 162, DateTimeKind.Local).AddTicks(3063), "INV005", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryAddressId",
                table: "Requests",
                column: "DeliveryAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PickupAddressId",
                table: "Requests",
                column: "PickupAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_AddressId",
                table: "ClientCompanies",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Addresses_AddressId",
                table: "ClientCompanies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Addresses_DeliveryAddressId",
                table: "Requests",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Addresses_PickupAddressId",
                table: "Requests",
                column: "PickupAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Addresses_AddressId",
                table: "ClientCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Addresses_DeliveryAddressId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Addresses_PickupAddressId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeliveryAddressId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PickupAddressId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_ClientCompanies_AddressId",
                table: "ClientCompanies");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d000e64-c056-419a-950f-1992bd1e910d", "20450cff-816f-49c8-9546-1c603aec0301" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "2e8be95a-186e-403b-b4aa-3874750a3563" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "38ba6810-2800-4ac8-b005-5c27e8248951" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99027aaa-d346-4dd9-a467-15d74576c080", "6bab54d5-5a88-4128-92d2-4d12ad0baa32" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser2" });

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2");

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1");

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PickupAddressId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ClientCompanies");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Requests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Delivery address");

            migrationBuilder.AddColumn<double>(
                name: "DeliveryLatitude",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Delivery address latitude");

            migrationBuilder.AddColumn<double>(
                name: "DeliveryLongitude",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Delivery address longitude");

            migrationBuilder.AddColumn<string>(
                name: "PickupAddress",
                table: "Requests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Pickup address");

            migrationBuilder.AddColumn<double>(
                name: "PickupLatitude",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Pickup address latitude");

            migrationBuilder.AddColumn<double>(
                name: "PickupLongitude",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Pickup address longitude");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ClientCompanies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Company's city");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ClientCompanies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Company's country");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "ClientCompanies",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                comment: "Company's postal code");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "ClientCompanies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Company's address");
        }
    }
}
