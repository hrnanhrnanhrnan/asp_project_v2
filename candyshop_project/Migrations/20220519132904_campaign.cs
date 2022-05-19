using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace candyshop_project.Migrations
{
    public partial class campaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Candies");

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    IsFlatAmount = table.Column<bool>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false),
                    CandyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Discount_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discount_Candies_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candies",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f2a2bed8-6d1e-41be-92b1-f8a26be9b96c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ceeacf-9ee9-4ebc-8bd5-a457d2f9a80a", "AQAAAAEAACcQAAAAEG4xO3Fyv7EH8HcAC/EGSd4yLX1u/8peNBlAjKZVzOQ5/uEqETZDfjdSjJTHUmGgcQ==", "564ab2a6-7674-46be-ba27-4a8345e46b7c" });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CampaignId",
                table: "Discount",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CandyId",
                table: "Discount",
                column: "CandyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Candies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b13b03c8-cf5f-4572-8a5a-cc09893af642");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3eb23ef2-1c40-4921-a899-5eea75510749", "AQAAAAEAACcQAAAAEAt5nv2DQdlv9i6tAVYKc1keUJxn/KQkoZPlELqksm576v9S6H1Gl21xv1I7IXv75g==", "65c54366-8627-435d-a93d-a51b9bca93dd" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 10,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                column: "IsOnSale",
                value: true);
        }
    }
}
