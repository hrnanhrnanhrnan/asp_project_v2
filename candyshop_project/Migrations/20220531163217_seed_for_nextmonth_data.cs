using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace candyshop_project.Migrations
{
    public partial class seed_for_nextmonth_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1cbdc99e-448b-4a33-b0f7-5af6a58cea88");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4adaf653-7fce-4725-acc3-3f51a5031ad1", "AQAAAAEAACcQAAAAEA9idgr1XluyKHmgZAkb+POH9icCRp4LW2t4dqrwqOh7NFqlZmB8R+B9I86CJSQ6sg==", "35d66920-eaa3-47dc-a1dd-b1472fb2151e" });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 36,
                columns: new[] { "Amount", "CandyId" },
                values: new object[] { 25, 9 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 37,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 17, 1, 18 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 38,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 7, 6, 18 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 39,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 12, 9, 4.95m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 40,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 25, 12, 6.95m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 41,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 17, 2, 20 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 42,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 29, 10, 3.95m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "State" },
                values: new object[] { "1165 Apple Lane", "Denver", "Keren", "R. Fields", new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.75m, "309-263-5674", "Alabama" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderTotal", "PhoneNumber", "State" },
                values: new object[] { "547 Davis Lane", "Pittsburg", "Peter", "D. Murphy", 178.2m, "720-323-6178", "California" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderTotal", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { "1165 Apple Lane", "Denver", "Keren", "R. Fields", 173.75m, "309-263-5674", "Alabama", "80216" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20,
                columns: new[] { "Address", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "ZipCode" },
                values: new object[] { "2886 Grey Fox Farm Road", "Rosie", "J. Fails", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181.7m, "281-834-4587", "95204" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Address", "City", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { 21, "827 Kennedy Court", "Pittsburg", "Eunice", "T. Stroud", new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.9m, "774-563-0433", "California", "02132" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "Amount", "CandyId", "OrderId", "Price" },
                values: new object[] { 43, 42, 14, 21, 2.95m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bdee995a-91dc-432b-b68e-d523f6e40dc5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f54249b-4a9a-4ece-9ef9-f2847b9e41d2", "AQAAAAEAACcQAAAAEBZMGZRECcQYn1V+lL+2iZm8tQj1C2CvKyFTVZtVeSto8MW+Y1qnWEyKd86yLgkKfA==", "7d675bc6-d148-4eb8-8ee4-0d4531f2de1e" });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 36,
                columns: new[] { "Amount", "CandyId" },
                values: new object[] { 17, 1 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 37,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 7, 6, 17 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 38,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 12, 9, 17 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 39,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 25, 12, 6.95m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 40,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 17, 2, 3.95m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 41,
                columns: new[] { "Amount", "CandyId", "OrderId" },
                values: new object[] { 29, 10, 19 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 42,
                columns: new[] { "Amount", "CandyId", "Price" },
                values: new object[] { 42, 14, 2.95m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "State" },
                values: new object[] { "547 Davis Lane", "Pittsburg", "Peter", "D. Murphy", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178.2m, "720-323-6178", "California" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderTotal", "PhoneNumber", "State" },
                values: new object[] { "1165 Apple Lane", "Denver", "Keren", "R. Fields", 173.75m, "309-263-5674", "Alabama" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19,
                columns: new[] { "Address", "City", "FirstName", "LastName", "OrderTotal", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { "2886 Grey Fox Farm Road", "Pittsburg", "Rosie", "J. Fails", 181.7m, "281-834-4587", "California", "95204" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20,
                columns: new[] { "Address", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "ZipCode" },
                values: new object[] { "827 Kennedy Court", "Eunice", "T. Stroud", new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.9m, "774-563-0433", "02132" });
        }
    }
}
