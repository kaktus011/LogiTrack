using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class NewInitMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "e89c5ba8-0e5e-4fc0-9330-bc8591306f28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "7351cca5-a9e9-4294-b71c-f0b2d904deda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "5d5ba508-ccf9-4161-9cc1-3276dc8c394b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "bbff760a-f0c3-4090-a763-9fc9838e82b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "0efdbbef-be63-4dd8-b31a-72bbc6077046");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e30b2ea-2149-4df1-86dd-4b711966968b", "AQAAAAEAACcQAAAAEDqe5Ii8CX6r5Mwr0OG29IaoSaKr4aBEJ0D7InG51ChiwGFw5kH0qepfL0n1YrxpeQ==", "ef306e6c-9d00-488e-8b97-99ef49fd0731" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84be6d78-0094-43d2-8ad0-041971739a1f", "AQAAAAEAACcQAAAAEExQMoSmDvVKTnmUpbM302lQ20dHMMX6KdGe7Ngin5nHwcVhEirw17gVDEVYAcW/LQ==", "d6d5135e-eb9a-48a3-b77b-c10d2025f87d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f03918a7-1abc-43b3-b3f4-af3310082537", "AQAAAAEAACcQAAAAEBkBnb4N7Dxzsl3YLtaI+hTKstIU7hDg4F/HJyNkPB62gnxdPg7apBVscjm0jFwsvw==", "9bd80047-7564-4305-a59d-6381c755a1c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff818981-88bd-4b40-9e49-1b2f9df80bef", "AQAAAAEAACcQAAAAEKt/rMpus8WHWDOVtstyu0cOhUBUfR+0oAxNDYFGWSdbyewlGcUJMf53ac0QVSE2JA==", "61cb2d35-d618-4235-9dd1-27b0f4ea573f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31033b20-319c-4d75-a2c8-40af83b5988b", "AQAAAAEAACcQAAAAEM7Y6rE+fus9lDmmUMph0eYQ7mMn63Hi4YyjiVMiVhLX0nHqhyY+7R/qijF+e1tacA==", "83c4bf6d-1c71-4696-894e-ca43607d38b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53800d4d-244f-4012-ae11-57ff09b2d1a7", "59331700-747c-417c-bee8-f56d27c074fa" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 10, 9, 41, 39, 955, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 10, 9, 41, 39, 955, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 10, 9, 41, 39, 955, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 5, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 9, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 10, 9, 41, 39, 863, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 9, 41, 39, 869, DateTimeKind.Local).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 31, 9, 41, 39, 869, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 9, 9, 41, 39, 924, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 8, 9, 41, 39, 924, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 9, 41, 39, 924, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 9, 41, 39, 924, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 5, 9, 41, 39, 924, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 5, 9, 41, 39, 937, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 9, 41, 39, 937, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 9, 41, 39, 937, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 8, 9, 41, 39, 937, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 9, 9, 41, 39, 937, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 10, 9, 41, 39, 909, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 10, 9, 41, 39, 909, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 7, 9, 41, 39, 949, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 8, 9, 41, 39, 949, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 31, 9, 41, 39, 876, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 9, 41, 39, 876, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 9, 41, 39, 876, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 3, 9, 41, 39, 876, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 4, 9, 41, 39, 876, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 31, 9, 41, 39, 882, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 2, 9, 41, 39, 882, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 5, 9, 41, 39, 882, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 9, 41, 39, 882, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 10, 9, 41, 39, 882, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8739), new DateTime(2024, 11, 17, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8736) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8743), new DateTime(2024, 11, 20, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8748), new DateTime(2024, 11, 25, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8752), new DateTime(2024, 11, 13, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8755), new DateTime(2024, 11, 14, 9, 41, 39, 890, DateTimeKind.Local).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 10, 9, 41, 39, 930, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 10, 9, 41, 39, 930, DateTimeKind.Local).AddTicks(8774));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "1930fed3-d06c-4a74-801e-9bcb9232f162");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "d9ae600f-03ad-4956-80c7-f83b67256774");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "ed75221f-be6c-4297-93ab-1daf2bbaceaa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "03391ef0-df95-4c02-9609-48c7e6ca22e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "3809e8c0-9c46-4fcb-96d8-358c3f21a382");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15f35b82-08e2-4306-a58d-7afd802f5958", "AQAAAAEAACcQAAAAEFCSXHg8fXy95nHQrX6jfK1HOfd6T6b62Yyk24rr9uV1+2TzhDGIXfv+O+xgBQseVA==", "e6cfc8fc-52bb-447c-8e4c-c33e0e74fe2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03063d31-f6d5-47de-a1ec-fb8342ee226c", "AQAAAAEAACcQAAAAELDF4TpD5TKaGIIAWGEjx2LBaHIwxfvbA1s9FFJ2HOIX16kkB5g+XS+7T0he7qLGWw==", "15ee532b-ff7e-4878-9755-948fbfe12ef2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a86f71b-65b9-48e5-9924-9bb1aaa575f1", "AQAAAAEAACcQAAAAECQ3iQBZ1M/Ncy2/AkHlbVhpuWRpZAhaf/CrzxlBnJOZSo979fm4VC+obicEWoJWBg==", "141ccea3-e654-464c-aedc-1dd2b8c2b403" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "173be186-0669-431d-b4fc-268b824f507f", "AQAAAAEAACcQAAAAEKO2axKupf6UrVp+RIJOZj+f0fHpbFgkAEiYDpXoftm5fawnKg8XZiG/Hj2Jm42mFg==", "3a24d25c-47d5-4f50-8c57-193611d3ccde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc560705-7d17-4efd-b7f9-d843651ee893", "AQAAAAEAACcQAAAAEMPYFlF3oC/BbaxkARhj/o5YuJwVLWlUbw+cLIzrSJNnFnoRKgTvE4wQOPnPj7guvw==", "611ff87c-5c14-4cf6-a642-35ac73ed63ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e01ef698-d190-49f7-a49b-18e8cb60b9c6", "f6927452-1e7a-4400-9d86-939979d48488" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 8, 13, 59, 59, 723, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 8, 13, 59, 59, 723, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 8, 13, 59, 59, 723, DateTimeKind.Local).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 3, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 4, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 5, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 13, 59, 57, 632, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 13, 59, 57, 639, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 13, 59, 57, 639, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 13, 59, 59, 692, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 13, 59, 59, 692, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 5, 13, 59, 59, 692, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 4, 13, 59, 59, 692, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 3, 13, 59, 59, 692, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 3, 13, 59, 59, 704, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 4, 13, 59, 59, 704, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 5, 13, 59, 59, 704, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 13, 59, 59, 704, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 13, 59, 59, 704, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 13, 59, 58, 469, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 13, 59, 58, 469, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 5, 13, 59, 59, 717, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 6, 13, 59, 59, 717, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 29, 13, 59, 57, 646, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 30, 13, 59, 57, 646, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 31, 13, 59, 57, 646, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 13, 59, 57, 646, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 13, 59, 57, 646, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 29, 13, 59, 57, 652, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 10, 31, 13, 59, 57, 652, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 3, 13, 59, 57, 652, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 13, 59, 57, 652, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 13, 59, 57, 652, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3267), new DateTime(2024, 11, 15, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3273), new DateTime(2024, 11, 18, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3293), new DateTime(2024, 11, 23, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3292) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3309), new DateTime(2024, 11, 11, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3308) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3319), new DateTime(2024, 11, 12, 13, 59, 58, 449, DateTimeKind.Local).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 8, 13, 59, 59, 698, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 8, 13, 59, 59, 698, DateTimeKind.Local).AddTicks(4824));
        }
    }
}
