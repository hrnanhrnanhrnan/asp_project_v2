using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace candyshop_project.Migrations
{
    public partial class initmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categores",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescriptin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categores", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Candies",
                columns: table => new
                {
                    CandyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candies", x => x.CandyId);
                    table.ForeignKey(
                        name: "FK_Candies_Categores_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categores",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    CandyId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Candies_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candies",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    CandyId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Candies_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candies",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "b13b03c8-cf5f-4572-8a5a-cc09893af642", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "3eb23ef2-1c40-4921-a899-5eea75510749", "admin@admin.se", false, false, null, "ADMIN@ADMIN.SE", "ADMIN@ADMIN.SE", "AQAAAAEAACcQAAAAEAt5nv2DQdlv9i6tAVYKc1keUJxn/KQkoZPlELqksm576v9S6H1Gl21xv1I7IXv75g==", null, false, "65c54366-8627-435d-a93d-a51b9bca93dd", false, "admin@admin.se" });

            migrationBuilder.InsertData(
                table: "Categores",
                columns: new[] { "CategoryId", "CategoryDescriptin", "CategoryName" },
                values: new object[,]
                {
                    { 5, null, "Hard Candy" },
                    { 1, null, "Chocolate Candy" },
                    { 3, null, "Gummy Candy" },
                    { 2, null, "Fruit Candy" },
                    { 4, null, "Halloween Candy" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Address", "City", "FirstName", "LastName", "OrderPlaced", "OrderTotal", "PhoneNumber", "State", "ZipCode" },
                values: new object[,]
                {
                    { 20, "827 Kennedy Court", "Pittsburg", "Eunice", "T. Stroud", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.9m, "774-563-0433", "California", "02132" },
                    { 19, "2886 Grey Fox Farm Road", "Pittsburg", "Rosie", "J. Fails", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181.7m, "281-834-4587", "California", "95204" },
                    { 18, "1165 Apple Lane", "Denver", "Keren", "R. Fields", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173.75m, "309-263-5674", "Alabama", "80216" },
                    { 17, "547 Davis Lane", "Pittsburg", "Peter", "D. Murphy", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178.2m, "720-323-6178", "California", "80216" },
                    { 16, "547 Davis Lane", "Pittsburg", "Peter", "D. Murphy", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 138.9m, "720-323-6178", "California", "80216" },
                    { 15, "827 Kennedy Court", "Pittsburg", "Eunice", "T. Stroud", new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 168.3m, "774-563-0433", "California", "02132" },
                    { 14, "547 Davis Lane", "Denver", "Peter", "D. Murphy", new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 149.05m, "720-323-6178", "Alabama", "80216" },
                    { 13, "2886 Grey Fox Farm Road", "Pittsburg", "Rosie", "J. Fails", new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.65m, "281-834-4587", "California", "77520" },
                    { 12, "1165 Apple Lane", "Denver", "Keren", "R. Fields", new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 173m, "309-263-5674", "Alabama", "80216" },
                    { 11, "547 Davis Lane", "Pittsburg", "Peter", "D. Murphy", new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 163.25m, "720-323-6178", "California", "80216" },
                    { 8, "3223 Stone Lane", "Pittsburg", "Antonio", "C. Real", new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 148.35m, "610-422-3906", "California", "80216" },
                    { 7, "2886 Grey Fox Farm Road", "Pittsburg", "Rosie", "J. Fails", new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 139.35m, "281-834-4587", "California", "77520" },
                    { 6, "3897 Allison Avenue", "Denver", "Robert", "A. McDonald", new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 157.45m, "757-548-3726", "Alabama", "23320" },
                    { 5, "827 Kennedy Court", "Pittsburg", "Eunice", "T. Stroud", new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.75m, "774-563-0433", "California", "02132" },
                    { 4, "4104 Riverwood Drive", "Pittsburg", "Joseph", " A. Schultz", new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 114.55m, "530-328-0168", "California", "95814" },
                    { 3, "1078 Park Street", "Pittsburg", "John", "N. Jeffers", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 128.5m, "925-439-8682", "California", "94565" },
                    { 2, "2389 Medical Center Drive", "Denver", "Stella", "S. McElroy", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.4m, "941-468-9331", "Alabama", "33610" },
                    { 1, "547 Davis Lane", "Denver", "Peter", "D. Murphy", new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 118.75m, "720-323-6178", "Alabama", "80216" },
                    { 10, "1165 Apple Lane", "Denver", "Keren", "R. Fields", new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 167.6m, "309-263-5674", "Alabama", "80216" },
                    { 9, "1233 Freed Drive", "Denver", "Walter", "K. Clark", new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 165.1m, "209-762-7688", "Alabama", "95204" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CategoryId", "Description", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\chocolateCandy3-small.jpg", "\\Images\\chocolet.candy.jpg", true, false, "Assorted Chocolet Candy", 4.95m },
                    { 2, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\chocolateCandy-small.jpg", "\\Images\\chocolateCandy.jpg", true, true, "Assorted Chocolet Candy", 3.95m },
                    { 3, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\chocolateCandy2-small.jpg", "\\Images\\chocolateCandy2.jpg", true, true, "Assorted Chocolet Candy", 2.95m },
                    { 4, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\FruitCandy-small.jpg", "\\Images\\FruitCandy.jpg", true, true, "Assorted Fruit Candy", 6.95m },
                    { 5, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\fruitCandy2-small.jpg", "\\Images\\fruitCandy2.jpg", true, false, "Assorted Fruit Candy", 3.95m },
                    { 6, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\fruitCandy3-small.jpg", "\\Images\\fruitCandy3.jpg", false, true, "Assorted Fruit Candy", 4.95m },
                    { 7, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\gummyCandy-small.jpg", "\\Images\\gummyCandy.jpg", true, false, "Assorted Gummy Candy", 4.95m },
                    { 8, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\gummyCandy2-small.jpg", "\\Images\\gummyCandy2.jpg", true, true, "Assorted Gummy Candy", 6.95m },
                    { 9, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\gummyCandy3-small.jpg", "\\Images\\gummyCandy3.jpg", true, true, "Assorted Gummy Candy", 4.95m },
                    { 10, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\halloweenCandy-small.jpg", "\\Images\\halloweenCandy.jpg", true, true, "Assorted Halloween Candy", 3.95m },
                    { 11, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\halloweenCandy2-small.jpg", "\\Images\\halloweenCandy2.jpg", false, true, "Assorted Halloween Candy", 5.95m },
                    { 12, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\halloweenCandy3-small.jpg", "\\Images\\halloweenCandy3.jpg", true, true, "Assorted Halloween Candy", 6.95m },
                    { 13, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\hardCandy-small.jpg", "\\Images\\hardCandy.jpg", true, false, "Assorted Hard Candy", 3.95m },
                    { 14, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\hardCandy2-small.jpg", "\\Images\\hardCandy2.jpg", false, true, "Assorted Hard Candy", 2.95m },
                    { 15, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "\\Images\\thumbnails\\hardCandy3-small.jpg", "\\Images\\hardCandy3.jpg", true, false, "Assorted Hard Candy", 5.95m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "Amount", "CandyId", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, 20, 1, 1, 4.95m },
                    { 33, 34, 9, 15, 4.95m },
                    { 38, 12, 9, 17, 4.95m },
                    { 7, 29, 10, 4, 3.95m },
                    { 12, 10, 10, 6, 3.95m },
                    { 18, 15, 10, 8, 3.95m },
                    { 22, 13, 10, 9, 3.95m },
                    { 30, 12, 10, 13, 3.95m },
                    { 34, 15, 10, 16, 3.95m },
                    { 41, 29, 10, 19, 3.95m },
                    { 6, 5, 12, 3, 6.95m },
                    { 13, 7, 12, 6, 6.95m },
                    { 17, 3, 12, 7, 6.95m },
                    { 26, 15, 12, 11, 6.95m },
                    { 39, 25, 12, 18, 6.95m },
                    { 9, 24, 14, 5, 2.95m },
                    { 21, 15, 14, 9, 2.95m },
                    { 23, 35, 14, 10, 2.95m },
                    { 19, 18, 9, 8, 4.95m },
                    { 29, 35, 14, 13, 2.95m },
                    { 37, 7, 6, 17, 4.95m },
                    { 28, 15, 6, 12, 4.95m },
                    { 3, 16, 1, 2, 4.95m },
                    { 10, 7, 1, 5, 4.95m },
                    { 14, 8, 1, 6, 4.95m },
                    { 24, 13, 1, 10, 4.95m },
                    { 36, 17, 1, 17, 4.95m },
                    { 2, 5, 2, 1, 3.95m },
                    { 16, 30, 2, 7, 3.95m },
                    { 27, 25, 2, 12, 3.95m },
                    { 40, 17, 2, 19, 3.95m },
                    { 4, 15, 3, 3, 2.95m },
                    { 8, 14, 3, 5, 2.95m },
                    { 25, 20, 3, 11, 2.95m },
                    { 31, 22, 3, 14, 2.95m },
                    { 35, 27, 3, 16, 2.95m },
                    { 20, 15, 4, 9, 6.95m },
                    { 5, 10, 6, 3, 4.95m },
                    { 15, 6, 6, 6, 4.95m },
                    { 32, 17, 6, 14, 4.95m },
                    { 42, 42, 14, 20, 2.95m }
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
                name: "IX_Candies_CategoryId",
                table: "Candies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CandyId",
                table: "OrderDetails",
                column: "CandyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CandyId",
                table: "ShoppingCartItems",
                column: "CandyId");
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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Candies");

            migrationBuilder.DropTable(
                name: "Categores");
        }
    }
}
