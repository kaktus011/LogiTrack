using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedTestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "0197bf1c-c45b-4ab3-b4a9-9529176ad2d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "77595aa3-9d05-4d6c-b6bf-b03f86b7e6c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "70b9f4f3-4247-45ba-a6d8-cf26a7990c87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "1cfb3a69-3376-4804-baab-6d8c67357020");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "5e500740-2df2-42fe-b728-ff3d188f22b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eac0cf76-460e-41c2-a53d-8f63cc2129a5", "AQAAAAEAACcQAAAAEET93QzDTRZzNWdcZ6mBut1UibZastNlt1InI1Ljab0rK3WgTzc06UkScUQQCTkh9w==", "f4f6d8ab-d939-468b-a367-2757ca6d0438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "642719e7-e12d-4f29-8bea-660152f29a6f", "AQAAAAEAACcQAAAAELTbOCPQSpaJy877OPq25HqAJmpI1CSnigYoncr1AcVp7fbCNQne9FrzOjdSJhKLnw==", "0feca1e8-70a1-425a-aeb7-39c5605cc564" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "067b4014-db21-44b8-926e-79ddbc01173b", "AQAAAAEAACcQAAAAEDe/TvBHsJ2PnENcVKvDnbpYdoMSk+f9Igbu3XU+87rUJvo2sjzgVL7MDhpohh0pYQ==", "c13a375e-4b6b-4816-8e87-6f3427bc5502" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26b8d7db-1f9c-4919-95c9-2a659f5f6a36", "AQAAAAEAACcQAAAAEKBQGmzTtmMDfLybZt08dCpPE82+4pQf1mQMYKKkJ3KP+Aa+AAg7EkhjLKiEfnJzew==", "b80ec278-eb83-458f-b44e-fe7acef10385" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d6eae2-f251-4c90-b9c9-ffc093e4380f", "AQAAAAEAACcQAAAAEJW5S/D67JUxu38o5vXq8vGIHulEKqD8TqvXRaN2fgv4QU7e23/ffH8bbo68VazThQ==", "3886660c-59b3-426c-99a8-6baca54a5e07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6712e09d-c1fd-4e83-a439-81331ec6d3c8", "AQAAAAEAACcQAAAAEIdMqdnMCgwWwNhmOAjXq0YqA2xRZ1AMVo7tXPMPJiwtM6HKknk+guI3BfasUMSMtA==", "1fff8883-6426-4018-89b2-ae5435c8c133" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 14, 0, 58, 33, 727, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 14, 0, 58, 33, 727, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 14, 0, 58, 33, 727, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 22, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 22, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 11, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 12, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 13, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 14, 0, 58, 33, 642, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 0, 58, 33, 649, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActualDeliveryDate", "Status" },
                values: new object[] { new DateTime(2025, 1, 21, 0, 58, 33, 697, DateTimeKind.Local).AddTicks(3309), "Delivered" });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 12, 0, 58, 33, 697, DateTimeKind.Local).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 11, 0, 58, 33, 697, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 10, 0, 58, 33, 697, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 0, 58, 33, 697, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 21, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 10, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 11, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 12, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 13, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.InsertData(
                table: "DeliveryTrackings",
                columns: new[] { "Id", "Address", "DeliveryId", "DriverId", "Latitude", "Longitude", "Notes", "StatusUpdate", "Timestamp" },
                values: new object[,]
                {
                    { 6, "Sliven, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Delivery in transit.", "In Transit", new DateTime(2025, 1, 21, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3709) },
                    { 7, "Sliven, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Collected cargo.", "Collected", new DateTime(2025, 1, 21, 0, 58, 33, 709, DateTimeKind.Local).AddTicks(3711) }
                });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 14, 0, 58, 33, 689, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 14, 0, 58, 33, 689, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 11, 0, 58, 33, 721, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 12, 0, 58, 33, 721, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2025, 1, 4, 0, 58, 33, 655, DateTimeKind.Local).AddTicks(2264), new DateTime(2025, 1, 9, 0, 58, 33, 655, DateTimeKind.Local).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 7, 0, 58, 33, 655, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 8, 0, 58, 33, 655, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 30, 0, 58, 33, 661, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 0, 58, 33, 661, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 30, 0, 58, 33, 661, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2025, 1, 2, 0, 58, 33, 661, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2025, 1, 1, 0, 58, 33, 661, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 25, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8383), new DateTime(2025, 1, 21, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8392), new DateTime(2025, 1, 24, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 23, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8396), new DateTime(2025, 1, 19, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 22, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8402), new DateTime(2025, 1, 11, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8406), new DateTime(2025, 1, 9, 0, 58, 33, 676, DateTimeKind.Local).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 14, 0, 58, 33, 703, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 14, 0, 58, 33, 703, DateTimeKind.Local).AddTicks(3284));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "00e03aa2-0858-4a8d-a6ea-c7bf2811213c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "bbe59eef-9d56-4764-89d4-826885925468");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "b66d85a5-fef6-4a49-a3fa-179233419383");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "da520cc5-fa11-49da-bbc0-8f77941c7459");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "db3ebab9-7d96-4e51-b4a8-b66f04ce897f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea232a7-0749-438e-8a12-f0a490509f4d", "AQAAAAEAACcQAAAAEPoW3bcncOkZE2G89z1DB5d2FE/OBEsHYrEhA6D+7qn0Zh/QP21TG9ih6oVNRX6jkA==", "6b4a0319-cf2b-4472-b4cd-5739e197ec10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efdab6f1-b53c-4667-85fb-cc88bcf8ed4c", "AQAAAAEAACcQAAAAEHsh/BjWsjFWU6SbRzibcyuEaGTpMF1sHtkfdlyFJkIMJFIbSD16r+6H/er8aOFEhA==", "77c81c10-b223-45c8-8a6c-3bddabc122e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0da8a746-bf93-457d-ba54-1fc08a285ef2", "AQAAAAEAACcQAAAAEFT/byxyE2gLw9Q3JIKYq88dNoDEhl3LWIvq2/qTd4xT4uLTeZksiMSEX2FWPlsNLw==", "dd7e9596-87a8-4670-9ffa-1c9264c37c93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b26ede8d-8dbc-4db0-8328-840cf57d6215", "AQAAAAEAACcQAAAAEMdmTrCypv8RkWlb/IOCM5tOcRK0u0aR6x5voyZQd7EYdJS+cJhsi+tWPZkwMrYrww==", "af9f44e8-a3f9-45de-9602-939a1fa553ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eea214e-607c-4272-ad54-bd9841cf4a5b", "AQAAAAEAACcQAAAAEBHQf+XzQigOABev9EVEjvnn0R27mIHgqSzHQpYUE59Omx8DRbvjm2mDxrfKmmpkCQ==", "a2c8ca2a-a6f4-4bdc-9e96-7becac448c06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3e7d8eb-e085-4a8e-9da0-fee872382159", "AQAAAAEAACcQAAAAELKZIKDDvhh55rVG0yJkrdnCHOhmyMmJ9qTvdvIkPhiIG7Bqrm6ifvoawfU9BplTUg==", "4102b09c-3f96-4ecd-8e1d-3c73cddf5770" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 13, 23, 58, 22, 693, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 8, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 9, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 10, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 11, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 12, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 13, 23, 58, 22, 607, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 27, 23, 58, 22, 614, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActualDeliveryDate", "Status" },
                values: new object[] { new DateTime(2025, 1, 12, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5294), "In Transit" });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 11, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 10, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 8, 23, 58, 22, 663, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 8, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 9, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 10, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 11, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 12, 23, 58, 22, 675, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 13, 23, 58, 22, 654, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 13, 23, 58, 22, 654, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 10, 23, 58, 22, 687, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 11, 23, 58, 22, 687, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2025, 1, 3, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4988), new DateTime(2025, 1, 8, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 6, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 7, 23, 58, 22, 620, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 28, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2025, 1, 1, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 12, 31, 23, 58, 22, 626, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 24, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(832), new DateTime(2025, 1, 20, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(829) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 23, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(839), new DateTime(2025, 1, 23, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(837) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 22, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(843), new DateTime(2025, 1, 18, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(842) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(847), new DateTime(2025, 1, 10, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 20, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(850), new DateTime(2025, 1, 8, 23, 58, 22, 642, DateTimeKind.Local).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 13, 23, 58, 22, 669, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 13, 23, 58, 22, 669, DateTimeKind.Local).AddTicks(3742));
        }
    }
}
