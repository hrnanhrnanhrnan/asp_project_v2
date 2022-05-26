using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace candyshop_project.Migrations
{
    public partial class seeddataforcampaignanddiscounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candies",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Candies",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2ca2d8b6-46f0-40d9-9825-7845e3cce43d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8780c8c7-e4ea-452e-acb9-e9faf2271380", "AQAAAAEAACcQAAAAEPJXBtpQtiZG5AKQhjs8bGDbbt+ZFa4GWSH6o0tGO7GLR4JPKQeVEFKl4Uy3kYszWg==", "c3ec1ab6-124d-40ed-9436-27c326bb3ae4" });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "ID", "Days", "Name", "Start" },
                values: new object[] { 1, 100, "Summer Sale", new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "ID", "Amount", "CampaignId", "CandyId", "IsFlatAmount" },
                values: new object[] { 1, 2.0, 1, 2, true });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "ID", "Amount", "CampaignId", "CandyId", "IsFlatAmount" },
                values: new object[] { 2, 3.0, 1, 12, true });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "ID", "Amount", "CampaignId", "CandyId", "IsFlatAmount" },
                values: new object[] { 3, 1.0, 1, 14, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Candies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e2bea85a-261c-47d9-ba4c-757c8a7059c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6caa1f71-4f0f-455b-8098-763ba54b4a83", "AQAAAAEAACcQAAAAEBtI4D3zY8s344GG2msXpF2ZD774Xpfo4CFnKiTx3/Q8ma7WK3FJrj6abrjZCngZsA==", "ab54430b-a0e0-4b5d-882c-f5e98aabdd4f" });
        }
    }
}
