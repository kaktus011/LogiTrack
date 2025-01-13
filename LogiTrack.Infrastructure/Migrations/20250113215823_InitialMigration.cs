using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Fuel Price identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Fuel price"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.Id);
                },
                comment: "Fuel Prices Entity");

            migrationBuilder.CreateTable(
                name: "StandartCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Standard cargo identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfPallet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Type of pallet"),
                    NumberOfPallets = table.Column<int>(type: "int", nullable: true, comment: "Number of pallets"),
                    PalletLength = table.Column<double>(type: "float", nullable: true, comment: "Pallet length"),
                    PalletWidth = table.Column<double>(type: "float", nullable: true, comment: "Pallet width"),
                    PalletHeight = table.Column<double>(type: "float", nullable: true, comment: "Pallet height"),
                    PalletVolume = table.Column<double>(type: "float", nullable: true, comment: "Pallet volume"),
                    WeightOfPallets = table.Column<double>(type: "float", nullable: true, comment: "Weight of pallets"),
                    PalletsAreStackable = table.Column<bool>(type: "bit", nullable: true, comment: "Are the pallets stackable")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartCargos", x => x.Id);
                },
                comment: "Standart Cargo Entity");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: false, comment: "Is vehicle refrigerated"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Vehicle registration number"),
                    VehicleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Vehicle type"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Vehicle length"),
                    Width = table.Column<double>(type: "float", nullable: false, comment: "Vehicle width"),
                    Height = table.Column<double>(type: "float", nullable: false, comment: "Vehicle height"),
                    Volume = table.Column<double>(type: "float", nullable: false, comment: "Vehicle volume"),
                    EuroPalletCapacity = table.Column<int>(type: "int", nullable: false, comment: "Euro pallets capacity"),
                    IndustrialPalletCapacity = table.Column<int>(type: "int", nullable: false, comment: "Industrial pallets capacity"),
                    ArePalletsStackable = table.Column<bool>(type: "bit", nullable: false, comment: "Are the pallets stackable"),
                    MaxWeightCapacity = table.Column<double>(type: "float", nullable: false, comment: "Max weight capacity"),
                    FuelConsumptionPer100Km = table.Column<double>(type: "float", nullable: false, comment: "Fuel consumption per 100 km"),
                    VehicleStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Vehicle status"),
                    LastYearMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Maintenance due date"),
                    KilometersDriven = table.Column<double>(type: "float", nullable: false, comment: "Kilometers driven"),
                    KilometersToChangeParts = table.Column<double>(type: "float", nullable: false, comment: "Kilometers to change parts"),
                    KilometersLeftToChangeParts = table.Column<double>(type: "float", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Vehicle's purchase price"),
                    EmissionFactor = table.Column<double>(type: "float", nullable: false, comment: "Emission factor (kg CO2 per liter)"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ContantsExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Vehicle's constant expences")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                },
                comment: "Vehicle Entity");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Calendar Event identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date"),
                    EventType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Event Type"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Calendar Event Entity");

            migrationBuilder.CreateTable(
                name: "ClientCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "User identifier"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company Name"),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's registration status"),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Person whom we are contacting"),
                    AlternativePhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Company's alternative phone number"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "Company's registration number"),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's industry"),
                    AddressId = table.Column<int>(type: "int", nullable: false, comment: "Address of the company identifier"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Registration created at")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Client Company Entity");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Driver's name"),
                    LicenseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Driver's license number"),
                    LicenseExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's license expiry date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Driver's salary"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Driver's age"),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Driver's year of experience"),
                    MonthsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Driver's months of experience"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Is driver available"),
                    Preferrences = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Driver's preferrences")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Driver Entity");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Notification identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Notification message"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Notification title"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Notification date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, comment: "Notification is read")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Notification Entity");

            migrationBuilder.CreateTable(
                name: "PricesPerSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Prices per size identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    QuotientForDomesticNotSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for domestic not shared truck"),
                    QuotientForDomesticSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for domestic shared truck"),
                    QuotientForInternationalNotSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for international not shared truck"),
                    QuotientForInternationalSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for international shared truck")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricesPerSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricesPerSize_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Prices per size entity");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Invoice identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice number"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Invoice date"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice description"),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, comment: "Is invoice paid"),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "File identifier in Google drive"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice status"),
                    PaidOnTime = table.Column<bool>(type: "bit", nullable: true, comment: "Is invoice paid on time"),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Invoice paid date"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Invoice Entity");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false, comment: "Client Company identifier"),
                    CargoType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Cargo type"),
                    NumberOfNonStandartGoods = table.Column<int>(type: "int", nullable: true, comment: "Number of non-standart goods"),
                    TypeOfGoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type of goods"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the request"),
                    PickupAddressId = table.Column<int>(type: "int", nullable: false, comment: "Pickup address identifier"),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false, comment: "Delivery address identifier"),
                    SharedTruck = table.Column<bool>(type: "bit", nullable: false, comment: "Will the vehicle be shared or no"),
                    ApproximatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Approximate price given by the company"),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Automatically calculated price"),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expected delivery date"),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Status of the request"),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Special instructions"),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: false, comment: "Is the cargo refrigerated"),
                    OfferId = table.Column<int>(type: "int", nullable: true, comment: "Offer identifier"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation"),
                    Kilometers = table.Column<double>(type: "float", nullable: false, comment: "Kilometers"),
                    RerefenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Reference number"),
                    StandartCargoId = table.Column<int>(type: "int", nullable: true, comment: "Standart cargo identifier"),
                    TotalWeight = table.Column<double>(type: "float", nullable: false, comment: "Total weight of the cargo"),
                    TotalVolume = table.Column<double>(type: "float", nullable: false, comment: "Total volume of the cargo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Addresses_PickupAddressId",
                        column: x => x.PickupAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_StandartCargos_StandartCargoId",
                        column: x => x.StandartCargoId,
                        principalTable: "StandartCargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Request Entity");

            migrationBuilder.CreateTable(
                name: "NonStandardCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Non-standard cargo identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Length of the goods"),
                    Width = table.Column<double>(type: "float", nullable: false, comment: "Width of the goods"),
                    Height = table.Column<double>(type: "float", nullable: false, comment: "Height of the goods"),
                    Volume = table.Column<double>(type: "float", nullable: false, comment: "Volume of the goods"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "Weight of the goods"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Description of the non-standard cargo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonStandardCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonStandardCargos_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Non-Standard Cargo Entity");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Company identifier"),
                    OfferStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Offer status"),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Offer date"),
                    DeliveryId = table.Column<int>(type: "int", nullable: true, comment: "Delivery identifier"),
                    OfferNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Offer number"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Offer Entity");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    OfferId = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Delivery status"),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Delivery total expenses"),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Delivery total income"),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Delivery reference number"),
                    DeliveryStep = table.Column<int>(type: "int", nullable: false),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true, comment: "Invoice identifier"),
                    CarbonEmission = table.Column<double>(type: "float", nullable: false, comment: "Carbon emission blueprint (in kg CO2)"),
                    SuggestedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Suggested date for delivery")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Delivery Entity");

            migrationBuilder.CreateTable(
                name: "ReservedForDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Reserved for delivery identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    OfferId = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedForDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cash Register identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the cash register"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the register"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the register"),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date submitted"),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "File identifier in Google drive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cash Register Entity");

            migrationBuilder.CreateTable(
                name: "DeliveryTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    StatusUpdate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Status update"),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Notes"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Timestamp"),
                    Latitude = table.Column<double>(type: "float", nullable: false, comment: "Latitude"),
                    Longitude = table.Column<double>(type: "float", nullable: false, comment: "Longitude"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Address")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Delivery Tracking Entity");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rating identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStars = table.Column<int>(type: "int", nullable: false, comment: "Rating stars"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Rating comment"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Rating Entity");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "County", "Latitude", "Longitude", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Metropolis", "Central", null, null, "10001", "123 Main St" },
                    { 2, "Gotham", "Westside", 40.712800000000001, -74.006, "10002", "456 Side St" },
                    { 3, "Star City", "Northside", 37.774900000000002, -122.4194, "10003", "789 Elm St" },
                    { 4, "Central City", "Eastville", 39.952599999999997, -75.165199999999999, "10004", "101 Pine St" },
                    { 5, "Smallville", "Southend", 38.029299999999999, -78.476699999999994, "10005", "202 Maple St" },
                    { 6, "Bludhaven", "Old Town", 36.8508, -76.285899999999998, "10006", "303 Oak St" },
                    { 7, "Coast City", "Downtown", 34.052199999999999, -118.2437, "10007", "404 Birch St" },
                    { 8, "National City", "West End", 32.715699999999998, -117.1611, "10008", "505 Cedar St" },
                    { 9, "Ivy Town", "Upper Hill", 40.758000000000003, -111.8762, "10009", "606 Cherry St" },
                    { 10, "Gateway City", "Harborview", 47.606200000000001, -122.3321, "10010", "707 Aspen St" },
                    { 11, "Opal City", "Lakeside", 35.2271, -80.843100000000007, "10011", "808 Willow St" },
                    { 12, "Fawcett City", "Midtown", 33.749000000000002, -84.388000000000005, "10012", "909 Fir St" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "00e03aa2-0858-4a8d-a6ea-c7bf2811213c", "Accountant", "ACCOUNTANT" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "bbe59eef-9d56-4764-89d4-826885925468", "Speditor", "SPEDITOR" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "b66d85a5-fef6-4a49-a3fa-179233419383", "Driver", "DRIVER" },
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "da520cc5-fa11-49da-bbc0-8f77941c7459", "ClientCompany", "CLIENTCOMPANY" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "db3ebab9-7d96-4e51-b4a8-b66f04ce897f", "LogisticsCompany", "LOGISTICSCOMPANY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20450cff-816f-49c8-9546-1c603aec0301", 0, "3ea232a7-0749-438e-8a12-f0a490509f4d", "clientcompany1@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEPoW3bcncOkZE2G89z1DB5d2FE/OBEsHYrEhA6D+7qn0Zh/QP21TG9ih6oVNRX6jkA==", "1234567890", false, "6b4a0319-cf2b-4472-b4cd-5739e197ec10", false, "clientcompany1" },
                    { "2e8be95a-186e-403b-b4aa-3874750a3563", 0, "efdab6f1-b53c-4667-85fb-cc88bcf8ed4c", "speditor@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEHsh/BjWsjFWU6SbRzibcyuEaGTpMF1sHtkfdlyFJkIMJFIbSD16r+6H/er8aOFEhA==", null, false, "77c81c10-b223-45c8-8a6c-3bddabc122e6", false, "speditor" },
                    { "38ba6810-2800-4ac8-b005-5c27e8248951", 0, "0da8a746-bf93-457d-ba54-1fc08a285ef2", "secretary@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEFT/byxyE2gLw9Q3JIKYq88dNoDEhl3LWIvq2/qTd4xT4uLTeZksiMSEX2FWPlsNLw==", null, false, "dd7e9596-87a8-4670-9ffa-1c9264c37c93", false, "accountant" },
                    { "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 0, "b26ede8d-8dbc-4db0-8328-840cf57d6215", "logistics@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEMdmTrCypv8RkWlb/IOCM5tOcRK0u0aR6x5voyZQd7EYdJS+cJhsi+tWPZkwMrYrww==", null, false, "af9f44e8-a3f9-45de-9602-939a1fa553ca", false, "logistics" },
                    { "driverUser1", 0, "4eea214e-607c-4272-ad54-bd9841cf4a5b", "driver1@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBHQf+XzQigOABev9EVEjvnn0R27mIHgqSzHQpYUE59Omx8DRbvjm2mDxrfKmmpkCQ==", "1234567893", false, "a2c8ca2a-a6f4-4bdc-9e96-7becac448c06", false, "driver" },
                    { "driverUser2", 0, "c3e7d8eb-e085-4a8e-9da0-fee872382159", "driver2@example.com", true, false, null, "DRIVER2@EXAMPLE.COM", "DRIVER2@EXAMPLE.COM", "AQAAAAEAACcQAAAAELKZIKDDvhh55rVG0yJkrdnCHOhmyMmJ9qTvdvIkPhiIG7Bqrm6ifvoawfU9BplTUg==", "0987654321", false, "4102b09c-3f96-4ecd-8e1d-3c73cddf5770", false, "driver2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "Date", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 23, 58, 22, 687, DateTimeKind.Local).AddTicks(4350), 2.50m },
                    { 2, new DateTime(2025, 1, 11, 23, 58, 22, 687, DateTimeKind.Local).AddTicks(4352), 2.60m }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId", "Description", "FileId", "InvoiceDate", "InvoiceNumber", "IsPaid", "PaidDate", "PaidOnTime", "Status" },
                values: new object[,]
                {
                    { 1, null, "Invoice for Delivery 1", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", new DateTime(2025, 1, 3, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4988), "INV001", true, new DateTime(2025, 1, 8, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4986), true, "Paid" },
                    { 2, null, "Invoice for Delivery 4", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", new DateTime(2025, 1, 6, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4991), "INV004", false, null, false, "Paid" },
                    { 3, null, "Invoice for Delivery 5", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", new DateTime(2025, 1, 7, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4993), "INV005", true, null, false, "Overdue" }
                });

            migrationBuilder.InsertData(
                table: "StandartCargos",
                columns: new[] { "Id", "NumberOfPallets", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "TypeOfPallet", "WeightOfPallets" },
                values: new object[,]
                {
                    { 1, 5, 100.0, 120.0, 0.95999999999999996, 80.0, true, "Euro", 500.0 },
                    { 2, 3, 110.0, 130.0, 1.29, 90.0, false, "Industrial", 700.0 },
                    { 3, 4, 100.0, 120.0, 0.95999999999999996, 80.0, true, "Standard", 450.0 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "ContantsExpenses", "EmissionFactor", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "IsAvailable", "IsRefrigerated", "KilometersDriven", "KilometersLeftToChangeParts", "KilometersToChangeParts", "LastYearMaintenance", "Length", "MaxWeightCapacity", "PurchasePrice", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 5000.0m, 2.6299999999999999, 33, 12.5, 2.7999999999999998, 20, false, false, 150000.0, 50000.0, 0.0, new DateTime(2024, 10, 13, 23, 58, 22, 669, DateTimeKind.Local).AddTicks(3739), 12.0, 18000.0, 75000.0m, "ABC123", "Available", "Truck", 84.0, 2.5 },
                    { 2, false, 2000.0m, 2.6299999999999999, 10, 8.0, 2.5, 8, false, false, 90000.0, 30000.0, 0.0, new DateTime(2024, 12, 13, 23, 58, 22, 669, DateTimeKind.Local).AddTicks(3742), 6.0, 3500.0, 25000.0m, "XYZ789", "Available", "Van", 30.0, 2.0 }
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
                table: "CalendarEvents",
                columns: new[] { "Id", "Date", "EventType", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4534), "Paid", "Monthly Payment Due", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { 2, new DateTime(2024, 10, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4536), "Paid", "Quarterly Review", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { 3, new DateTime(2024, 7, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4538), "Delivered", "Annual Delivery Milestone", "20450cff-816f-49c8-9546-1c603aec0301" }
                });

            migrationBuilder.InsertData(
                table: "ClientCompanies",
                columns: new[] { "Id", "AddressId", "AlternativePhoneNumber", "ContactPerson", "CreatedAt", "Industry", "Name", "RegistrationNumber", "RegistrationStatus", "UserId" },
                values: new object[] { 1, 1, "1234567891", "John Doe", new DateTime(2024, 6, 27, 23, 58, 22, 614, DateTimeKind.Local).AddTicks(4488), "Manufacturing", "Client Company 1", "REG123456", "Approved", "20450cff-816f-49c8-9546-1c603aec0301" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, 30, true, new DateTime(2026, 1, 13, 23, 58, 22, 654, DateTimeKind.Local).AddTicks(6414), "D12345678", 6, "John Doe", "No night shifts", 3000.0m, "driverUser1", 5 },
                    { 2, 28, false, new DateTime(2026, 1, 13, 23, 58, 22, 654, DateTimeKind.Local).AddTicks(6418), "D87654321", 8, "Jane Smith", "Prefers city deliveries", 3200.0m, "driverUser2", 4 }
                });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1.2, 0.90000000000000002, 1.5, 1.1000000000000001, 1 },
                    { 2, 1.3, 0.84999999999999998, 1.6000000000000001, 1.2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryAddressId", "ExpectedDeliveryDate", "IsRefrigerated", "Kilometers", "NumberOfNonStandartGoods", "OfferId", "PickupAddressId", "RerefenceNumber", "SharedTruck", "SpecialInstructions", "StandartCargoId", "Status", "TotalVolume", "TotalWeight", "Type", "TypeOfGoods" },
                values: new object[,]
                {
                    { 1, 500m, 450m, "Standard", 1, new DateTime(2024, 12, 24, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(832), 4, new DateTime(2025, 1, 20, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(829), false, 500.0, null, null, 3, "R0001", false, "Handle with care", 1, "Approved", 12.0, 300.0, "Domestic", "Electronics" },
                    { 2, 1200m, 1150m, "Standard", 1, new DateTime(2024, 12, 23, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(839), 6, new DateTime(2025, 1, 23, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(837), false, 1000.0, null, null, 5, "R0002", true, "Keep dry", 2, "Approved", 20.0, 500.0, "International", "Furniture" },
                    { 3, 2000m, 1900m, "Non-Standard", 1, new DateTime(2024, 12, 22, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(843), 8, new DateTime(2025, 1, 18, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(842), false, 2000.0, null, null, 7, "R0003", false, "Requires crane", null, "Approved", 50.0, 2000.0, "Domestic", "Machinery" },
                    { 4, 350m, 340m, "Standard", 1, new DateTime(2024, 12, 21, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(847), 10, new DateTime(2025, 1, 10, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(845), false, 500.0, null, null, 9, "R0004", true, "Do not compress", 3, "Approved", 8.0, 150.0, "Domestic", "Textiles" },
                    { 5, 220m, 210m, "Non Standard", 1, new DateTime(2024, 12, 20, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(850), 12, new DateTime(2025, 1, 8, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(849), false, 1000.0, null, null, 11, "R0005", false, "Fragile binding", null, "Approved", 1.8, 300.0, "International", "Books" }
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
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "OfferDate", "OfferNumber", "OfferStatus", "RequestId" },
                values: new object[,]
                {
                    { 1, null, null, 1200.0m, new DateTime(2024, 12, 29, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4161), "OFFER0001", "Approved", 1 },
                    { 2, null, null, 1500.0m, new DateTime(2024, 12, 28, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4163), "OFFER0002", "Approved", 2 },
                    { 3, null, null, 1800.0m, new DateTime(2024, 12, 29, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4164), "OFFER0003", "Approved", 3 },
                    { 4, null, null, 2100.0m, new DateTime(2025, 1, 1, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4166), "OFFER0004", "Approved", 4 },
                    { 5, null, null, 2300.0m, new DateTime(2024, 12, 31, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4167), "OFFER0005", "Approved", 5 }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "ActualDeliveryDate", "CarbonEmission", "DeliveryStep", "DriverId", "InvoiceId", "OfferId", "Profit", "ReferenceNumber", "Status", "SuggestedDate", "TotalExpenses", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 12, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5294), 38.700000000000003, 2, 1, 1, 1, 750.00m, "DEL0001", "In Transit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.00m, 1 },
                    { 2, new DateTime(2025, 1, 11, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5297), 40.0, 1, 1, null, 2, 700.00m, "DEL0002", "Booked", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 450.00m, 1 },
                    { 3, new DateTime(2025, 1, 10, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5299), 35.0, 4, 1, null, 3, 800.00m, "DEL0003", "Delivered", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.00m, 1 },
                    { 4, new DateTime(2025, 1, 9, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5303), 45.0, 2, 1, 3, 4, 780.00m, "DEL0004", "In Transit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 520.00m, 1 },
                    { 5, new DateTime(2025, 1, 8, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5306), 50.0, 3, 1, 2, 5, 720.00m, "DEL0005", "Booked", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 480.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[,]
                {
                    { 1, 100.00m, new DateTime(2025, 1, 8, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3803), 1, "Fuel Expense", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Vehicle Expenses" },
                    { 2, 50.00m, new DateTime(2025, 1, 9, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3806), 1, "Toll Fee", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Vehicle Expenses" },
                    { 3, 20.00m, new DateTime(2025, 1, 10, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3807), 2, "Driver Lunch", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Driver Expenses" },
                    { 4, 150.00m, new DateTime(2025, 1, 11, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3809), 3, "Repair Costs", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Vehicle Expenses" },
                    { 5, 80.00m, new DateTime(2025, 1, 12, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3811), 4, "Accommodation", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Driver Expenses" },
                    { 6, 40.00m, new DateTime(2025, 1, 13, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3812), 5, "Miscellaneous", "1hcVFpCA0Mh1txKh0KbCbDR5N_QAoTFLq", "Other Expenses" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTrackings",
                columns: new[] { "Id", "Address", "DeliveryId", "DriverId", "Latitude", "Longitude", "Notes", "StatusUpdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Sofia, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Delivery completed successfully.", "Delivered", new DateTime(2025, 1, 8, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4244) },
                    { 2, "Varna, Bulgaria", 2, 1, 43.214100000000002, 27.9147, "Delivery scheduled.", "Booked", new DateTime(2025, 1, 9, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4246) },
                    { 3, "Plovdiv, Bulgaria", 3, 1, 42.135399999999997, 24.7453, "Delivered on time.", "Delivered", new DateTime(2025, 1, 10, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4248) },
                    { 4, "Kardzhali, Bulgaria", 4, 1, 41.632100000000001, 25.379000000000001, "Awaiting driver assignment.", "Delivered", new DateTime(2025, 1, 11, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4252) },
                    { 5, "Burgas, Bulgaria", 5, 1, 42.504800000000003, 27.462599999999998, "Package left with neighbor.", "Booked", new DateTime(2025, 1, 12, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4256) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_UserId",
                table: "CalendarEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_DeliveryId",
                table: "CashRegisters",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_AddressId",
                table: "ClientCompanies",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_UserId",
                table: "ClientCompanies",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_InvoiceId",
                table: "Deliveries",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OfferId",
                table: "Deliveries",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DriverId",
                table: "Deliveries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_VehicleId",
                table: "Deliveries",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_DeliveryId",
                table: "DeliveryTrackings",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_DriverId",
                table: "DeliveryTrackings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientCompanyId",
                table: "Invoices",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_NonStandardCargos_RequestId",
                table: "NonStandardCargos",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_DeliveryId",
                table: "Offers",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_RequestId",
                table: "Offers",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ClientCompanyId",
                table: "Offers",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PricesPerSize_VehicleId",
                table: "PricesPerSize",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DeliveryId",
                table: "Ratings",
                column: "DeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientCompanyId",
                table: "Requests",
                column: "ClientCompanyId");

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
                name: "IX_Requests_StandartCargoId",
                table: "Requests",
                column: "StandartCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_DriverId",
                table: "ReservedForDeliveries",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_OfferId",
                table: "ReservedForDeliveries",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_RequestId",
                table: "ReservedForDeliveries",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_VehicleId",
                table: "ReservedForDeliveries",
                column: "VehicleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "DeliveryTrackings");

            migrationBuilder.DropTable(
                name: "FuelPrices");

            migrationBuilder.DropTable(
                name: "NonStandardCargos");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PricesPerSize");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ReservedForDeliveries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ClientCompanies");

            migrationBuilder.DropTable(
                name: "StandartCargos");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
