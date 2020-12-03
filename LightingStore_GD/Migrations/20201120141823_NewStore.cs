using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingStore_GD.Migrations
{
    public partial class NewStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Carts_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Chandelier" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Wall Light" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Table Light" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CategoryName", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Chandelier", "Description1", "Product - Chandelier", 162m },
                    { 24, 3, "Table Light", "Description24", "Product - Table Light", 127m },
                    { 23, 3, "Table Light", "Description23", "Product - Table Light", 79m },
                    { 22, 3, "Table Light", "Description22", "Product - Table Light", 197m },
                    { 21, 3, "Table Light", "Description21", "Product - Table Light", 46m },
                    { 17, 3, "Table Light", "Description17", "Product - Table Light", 43m },
                    { 16, 3, "Table Light", "Description16", "Product - Table Light", 114m },
                    { 11, 3, "Table Light", "Description11", "Product - Table Light", 465m },
                    { 2, 3, "Table Light", "Description2", "Product - Table Light", 465m },
                    { 94, 2, "Wall Light", "Description94", "Product - Wall Light", 65m },
                    { 93, 2, "Wall Light", "Description93", "Product - Wall Light", 207m },
                    { 88, 2, "Wall Light", "Description88", "Product - Wall Light", 365m },
                    { 84, 2, "Wall Light", "Description84", "Product - Wall Light", 303m },
                    { 83, 2, "Wall Light", "Description83", "Product - Wall Light", 102m },
                    { 80, 2, "Wall Light", "Description80", "Product - Wall Light", 340m },
                    { 78, 2, "Wall Light", "Description78", "Product - Wall Light", 310m },
                    { 73, 2, "Wall Light", "Description73", "Product - Wall Light", 268m },
                    { 72, 2, "Wall Light", "Description72", "Product - Wall Light", 253m },
                    { 63, 2, "Wall Light", "Description63", "Product - Wall Light", 211m },
                    { 62, 2, "Wall Light", "Description62", "Product - Wall Light", 291m },
                    { 61, 2, "Wall Light", "Description61", "Product - Wall Light", 381m },
                    { 59, 2, "Wall Light", "Description59", "Product - Wall Light", 322m },
                    { 26, 3, "Table Light", "Description26", "Product - Table Light", 473m },
                    { 57, 2, "Wall Light", "Description57", "Product - Wall Light", 149m },
                    { 33, 3, "Table Light", "Description33", "Product - Table Light", 65m },
                    { 38, 3, "Table Light", "Description38", "Product - Table Light", 243m },
                    { 97, 3, "Table Light", "Description97", "Product - Table Light", 71m },
                    { 95, 3, "Table Light", "Description95", "Product - Table Light", 55m },
                    { 92, 3, "Table Light", "Description92", "Product - Table Light", 203m },
                    { 91, 3, "Table Light", "Description91", "Product - Table Light", 488m },
                    { 90, 3, "Table Light", "Description90", "Product - Table Light", 297m },
                    { 86, 3, "Table Light", "Description86", "Product - Table Light", 244m },
                    { 81, 3, "Table Light", "Description81", "Product - Table Light", 146m },
                    { 79, 3, "Table Light", "Description79", "Product - Table Light", 434m },
                    { 75, 3, "Table Light", "Description75", "Product - Table Light", 164m },
                    { 71, 3, "Table Light", "Description71", "Product - Table Light", 260m },
                    { 69, 3, "Table Light", "Description69", "Product - Table Light", 348m },
                    { 68, 3, "Table Light", "Description68", "Product - Table Light", 134m },
                    { 67, 3, "Table Light", "Description67", "Product - Table Light", 374m },
                    { 66, 3, "Table Light", "Description66", "Product - Table Light", 119m },
                    { 65, 3, "Table Light", "Description65", "Product - Table Light", 349m },
                    { 60, 3, "Table Light", "Description60", "Product - Table Light", 403m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CategoryName", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 58, 3, "Table Light", "Description58", "Product - Table Light", 486m },
                    { 52, 3, "Table Light", "Description52", "Product - Table Light", 76m },
                    { 43, 3, "Table Light", "Description43", "Product - Table Light", 318m },
                    { 41, 3, "Table Light", "Description41", "Product - Table Light", 468m },
                    { 39, 3, "Table Light", "Description39", "Product - Table Light", 196m },
                    { 36, 3, "Table Light", "Description36", "Product - Table Light", 489m },
                    { 98, 3, "Table Light", "Description98", "Product - Table Light", 196m },
                    { 56, 2, "Wall Light", "Description56", "Product - Wall Light", 198m },
                    { 54, 2, "Wall Light", "Description54", "Product - Wall Light", 283m },
                    { 76, 1, "Chandelier", "Description76", "Product - Chandelier", 170m },
                    { 74, 1, "Chandelier", "Description74", "Product - Chandelier", 478m },
                    { 70, 1, "Chandelier", "Description70", "Product - Chandelier", 105m },
                    { 64, 1, "Chandelier", "Description64", "Product - Chandelier", 454m },
                    { 49, 1, "Chandelier", "Description49", "Product - Chandelier", 222m },
                    { 46, 1, "Chandelier", "Description46", "Product - Chandelier", 25m },
                    { 44, 1, "Chandelier", "Description44", "Product - Chandelier", 111m },
                    { 42, 1, "Chandelier", "Description42", "Product - Chandelier", 337m },
                    { 37, 1, "Chandelier", "Description37", "Product - Chandelier", 392m },
                    { 35, 1, "Chandelier", "Description35", "Product - Chandelier", 407m },
                    { 34, 1, "Chandelier", "Description34", "Product - Chandelier", 53m },
                    { 31, 1, "Chandelier", "Description31", "Product - Chandelier", 392m },
                    { 29, 1, "Chandelier", "Description29", "Product - Chandelier", 145m },
                    { 25, 1, "Chandelier", "Description25", "Product - Chandelier", 162m },
                    { 20, 1, "Chandelier", "Description20", "Product - Chandelier", 20m },
                    { 15, 1, "Chandelier", "Description15", "Product - Chandelier", 452m },
                    { 13, 1, "Chandelier", "Description13", "Product - Chandelier", 428m },
                    { 12, 1, "Chandelier", "Description12", "Product - Chandelier", 211m },
                    { 10, 1, "Chandelier", "Description10", "Product - Chandelier", 381m },
                    { 5, 1, "Chandelier", "Description5", "Product - Chandelier", 409m },
                    { 3, 1, "Chandelier", "Description3", "Product - Chandelier", 444m },
                    { 77, 1, "Chandelier", "Description77", "Product - Chandelier", 176m },
                    { 55, 2, "Wall Light", "Description55", "Product - Wall Light", 325m },
                    { 82, 1, "Chandelier", "Description82", "Product - Chandelier", 297m },
                    { 87, 1, "Chandelier", "Description87", "Product - Chandelier", 220m },
                    { 53, 2, "Wall Light", "Description53", "Product - Wall Light", 241m },
                    { 51, 2, "Wall Light", "Description51", "Product - Wall Light", 192m },
                    { 50, 2, "Wall Light", "Description50", "Product - Wall Light", 198m },
                    { 48, 2, "Wall Light", "Description48", "Product - Wall Light", 372m },
                    { 47, 2, "Wall Light", "Description47", "Product - Wall Light", 43m },
                    { 45, 2, "Wall Light", "Description45", "Product - Wall Light", 214m },
                    { 40, 2, "Wall Light", "Description40", "Product - Wall Light", 431m },
                    { 32, 2, "Wall Light", "Description32", "Product - Wall Light", 46m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CategoryName", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 30, 2, "Wall Light", "Description30", "Product - Wall Light", 488m },
                    { 28, 2, "Wall Light", "Description28", "Product - Wall Light", 418m },
                    { 27, 2, "Wall Light", "Description27", "Product - Wall Light", 263m },
                    { 19, 2, "Wall Light", "Description19", "Product - Wall Light", 102m },
                    { 18, 2, "Wall Light", "Description18", "Product - Wall Light", 237m },
                    { 14, 2, "Wall Light", "Description14", "Product - Wall Light", 283m },
                    { 9, 2, "Wall Light", "Description9", "Product - Wall Light", 403m },
                    { 8, 2, "Wall Light", "Description8", "Product - Wall Light", 262m },
                    { 7, 2, "Wall Light", "Description7", "Product - Wall Light", 34m },
                    { 6, 2, "Wall Light", "Description6", "Product - Wall Light", 243m },
                    { 4, 2, "Wall Light", "Description4", "Product - Wall Light", 53m },
                    { 96, 1, "Chandelier", "Description96", "Product - Chandelier", 413m },
                    { 89, 1, "Chandelier", "Description89", "Product - Chandelier", 327m },
                    { 85, 1, "Chandelier", "Description85", "Product - Chandelier", 172m },
                    { 99, 3, "Table Light", "Description99", "Product - Table Light", 273m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 1 },
                    { 66, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 17 },
                    { 65, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 17 },
                    { 64, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 16 },
                    { 63, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 16 },
                    { 62, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 16 },
                    { 61, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 16 },
                    { 44, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 11 },
                    { 43, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 11 },
                    { 42, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 11 },
                    { 67, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 17 },
                    { 41, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 11 },
                    { 7, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 2 },
                    { 6, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 2 },
                    { 5, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 2 },
                    { 376, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 94 },
                    { 375, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 94 },
                    { 374, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 94 },
                    { 373, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 94 },
                    { 372, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 93 },
                    { 371, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 93 },
                    { 8, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 2 },
                    { 68, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 17 },
                    { 81, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 21 },
                    { 82, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 21 },
                    { 131, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 33 },
                    { 130, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 33 },
                    { 129, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 33 },
                    { 104, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 26 },
                    { 103, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 26 },
                    { 102, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 26 },
                    { 101, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 26 },
                    { 96, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 24 },
                    { 95, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 24 },
                    { 94, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 24 },
                    { 93, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 24 },
                    { 92, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 23 },
                    { 91, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 23 },
                    { 90, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 23 },
                    { 89, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 23 },
                    { 88, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 22 },
                    { 87, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 22 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 86, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 22 },
                    { 85, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 22 },
                    { 84, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 21 },
                    { 83, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 21 },
                    { 370, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 93 },
                    { 369, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 93 },
                    { 352, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 88 },
                    { 351, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 88 },
                    { 285, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 72 },
                    { 252, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 63 },
                    { 251, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 63 },
                    { 250, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 63 },
                    { 249, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 63 },
                    { 248, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 62 },
                    { 247, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 62 },
                    { 246, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 62 },
                    { 245, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 62 },
                    { 244, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 61 },
                    { 243, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 61 },
                    { 242, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 61 },
                    { 241, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 61 },
                    { 236, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 59 },
                    { 235, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 59 },
                    { 234, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 59 },
                    { 233, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 59 },
                    { 228, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 57 },
                    { 227, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 57 },
                    { 226, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 57 },
                    { 225, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 57 },
                    { 286, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 72 },
                    { 132, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 33 },
                    { 287, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 72 },
                    { 289, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 73 },
                    { 350, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 88 },
                    { 349, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 88 },
                    { 336, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 84 },
                    { 335, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 84 },
                    { 334, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 84 },
                    { 333, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 84 },
                    { 332, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 83 },
                    { 331, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 83 },
                    { 330, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 83 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 329, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 83 },
                    { 320, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 80 },
                    { 319, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 80 },
                    { 318, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 80 },
                    { 317, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 80 },
                    { 312, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 78 },
                    { 311, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 78 },
                    { 310, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 78 },
                    { 309, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 78 },
                    { 292, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 73 },
                    { 291, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 73 },
                    { 290, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 73 },
                    { 288, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 72 },
                    { 224, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 56 },
                    { 141, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 36 },
                    { 143, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 36 },
                    { 357, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 90 },
                    { 344, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 86 },
                    { 343, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 86 },
                    { 342, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 86 },
                    { 341, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 86 },
                    { 324, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 81 },
                    { 323, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 81 },
                    { 322, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 81 },
                    { 321, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 81 },
                    { 358, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 90 },
                    { 316, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 79 },
                    { 314, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 79 },
                    { 313, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 79 },
                    { 300, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 75 },
                    { 299, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 75 },
                    { 298, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 75 },
                    { 297, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 75 },
                    { 284, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 71 },
                    { 283, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 71 },
                    { 282, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 71 },
                    { 315, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 79 },
                    { 359, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 90 },
                    { 360, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 90 },
                    { 361, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 91 },
                    { 394, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 99 },
                    { 393, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 99 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 392, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 98 },
                    { 391, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 98 },
                    { 390, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 98 },
                    { 389, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 98 },
                    { 388, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 97 },
                    { 387, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 97 },
                    { 386, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 97 },
                    { 385, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 97 },
                    { 380, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 95 },
                    { 379, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 95 },
                    { 378, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 95 },
                    { 377, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 95 },
                    { 368, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 92 },
                    { 367, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 92 },
                    { 366, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 92 },
                    { 365, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 92 },
                    { 364, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 91 },
                    { 363, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 91 },
                    { 362, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 91 },
                    { 281, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 71 },
                    { 276, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 69 },
                    { 275, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 69 },
                    { 274, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 69 },
                    { 208, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 52 },
                    { 207, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 52 },
                    { 206, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 52 },
                    { 205, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 52 },
                    { 172, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 43 },
                    { 171, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 43 },
                    { 170, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 43 },
                    { 169, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 43 },
                    { 164, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 41 },
                    { 163, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 41 },
                    { 162, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 41 },
                    { 161, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 41 },
                    { 156, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 39 },
                    { 155, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 39 },
                    { 154, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 39 },
                    { 153, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 39 },
                    { 152, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 38 },
                    { 151, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 38 },
                    { 150, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 38 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 149, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 38 },
                    { 144, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 36 },
                    { 229, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 58 },
                    { 142, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 36 },
                    { 230, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 58 },
                    { 232, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 58 },
                    { 273, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 69 },
                    { 272, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 68 },
                    { 271, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 68 },
                    { 270, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 68 },
                    { 269, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 68 },
                    { 268, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 67 },
                    { 267, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 67 },
                    { 266, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 67 },
                    { 265, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 67 },
                    { 264, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 66 },
                    { 263, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 66 },
                    { 262, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 66 },
                    { 261, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 66 },
                    { 260, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 65 },
                    { 259, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 65 },
                    { 258, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 65 },
                    { 257, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 65 },
                    { 240, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 60 },
                    { 239, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 60 },
                    { 238, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 60 },
                    { 237, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 60 },
                    { 231, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 58 },
                    { 223, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 56 },
                    { 222, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 56 },
                    { 221, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 56 },
                    { 195, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 49 },
                    { 194, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 49 },
                    { 193, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 49 },
                    { 184, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 46 },
                    { 183, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 46 },
                    { 182, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 46 },
                    { 181, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 46 },
                    { 176, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 44 },
                    { 175, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 44 },
                    { 196, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 49 },
                    { 174, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 44 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 168, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 42 },
                    { 167, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 42 },
                    { 166, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 42 },
                    { 165, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 42 },
                    { 148, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 37 },
                    { 147, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 37 },
                    { 146, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 37 },
                    { 145, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 37 },
                    { 140, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 35 },
                    { 173, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 44 },
                    { 253, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 64 },
                    { 254, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 64 },
                    { 255, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 64 },
                    { 328, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 82 },
                    { 327, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 82 },
                    { 326, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 82 },
                    { 325, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 82 },
                    { 308, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 77 },
                    { 307, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 77 },
                    { 306, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 77 },
                    { 305, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 77 },
                    { 304, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 76 },
                    { 303, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 76 },
                    { 302, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 76 },
                    { 301, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 76 },
                    { 296, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 74 },
                    { 295, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 74 },
                    { 294, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 74 },
                    { 293, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 74 },
                    { 280, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 70 },
                    { 279, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 70 },
                    { 278, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 70 },
                    { 277, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 70 },
                    { 256, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 64 },
                    { 139, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 35 },
                    { 138, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 35 },
                    { 137, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 35 },
                    { 136, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 34 },
                    { 50, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 13 },
                    { 49, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 13 },
                    { 48, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 12 },
                    { 47, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 46, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 12 },
                    { 45, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 12 },
                    { 40, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 10 },
                    { 39, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 10 },
                    { 38, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 10 },
                    { 37, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 10 },
                    { 20, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 5 },
                    { 19, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 5 },
                    { 18, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 5 },
                    { 17, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 5 },
                    { 12, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 3 },
                    { 11, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 3 },
                    { 10, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 3 },
                    { 9, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 3 },
                    { 4, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 1 },
                    { 3, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 1 },
                    { 2, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 1 },
                    { 51, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 13 },
                    { 337, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 85 },
                    { 52, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 13 },
                    { 58, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 15 },
                    { 135, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 34 },
                    { 134, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 34 },
                    { 133, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 34 },
                    { 124, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 31 },
                    { 123, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 31 },
                    { 122, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 31 },
                    { 121, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 31 },
                    { 116, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 29 },
                    { 115, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 29 },
                    { 114, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 29 },
                    { 113, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 29 },
                    { 100, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 25 },
                    { 99, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 25 },
                    { 98, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 25 },
                    { 97, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 25 },
                    { 80, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 20 },
                    { 79, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 20 },
                    { 78, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 20 },
                    { 77, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 20 },
                    { 60, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 15 },
                    { 59, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 15 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 57, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 15 },
                    { 338, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 85 },
                    { 339, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 85 },
                    { 340, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 85 },
                    { 187, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 47 },
                    { 186, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 47 },
                    { 185, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 47 },
                    { 180, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 45 },
                    { 179, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 45 },
                    { 178, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 45 },
                    { 177, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 45 },
                    { 160, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 40 },
                    { 159, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 40 },
                    { 158, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 40 },
                    { 157, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 40 },
                    { 128, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 32 },
                    { 127, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 32 },
                    { 126, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 32 },
                    { 125, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 32 },
                    { 120, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 30 },
                    { 119, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 30 },
                    { 118, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 30 },
                    { 117, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 30 },
                    { 112, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 28 },
                    { 111, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 28 },
                    { 188, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 47 },
                    { 110, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 28 },
                    { 189, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 48 },
                    { 191, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 48 },
                    { 220, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 55 },
                    { 219, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 55 },
                    { 218, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 55 },
                    { 217, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 55 },
                    { 216, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 54 },
                    { 215, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 54 },
                    { 214, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 54 },
                    { 213, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 54 },
                    { 212, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 53 },
                    { 211, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 53 },
                    { 210, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 53 },
                    { 209, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 53 },
                    { 204, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 51 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 203, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 51 },
                    { 202, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 51 },
                    { 201, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 51 },
                    { 200, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 50 },
                    { 199, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 50 },
                    { 198, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 50 },
                    { 197, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 50 },
                    { 192, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 48 },
                    { 190, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 48 },
                    { 395, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 99 },
                    { 109, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 28 },
                    { 107, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 27 },
                    { 25, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 7 },
                    { 24, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 6 },
                    { 23, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 6 },
                    { 22, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 6 },
                    { 21, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 6 },
                    { 16, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 4 },
                    { 15, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 4 },
                    { 14, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 4 },
                    { 13, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 4 },
                    { 384, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 96 },
                    { 383, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 96 },
                    { 382, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 96 },
                    { 381, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 96 },
                    { 356, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 89 },
                    { 355, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 89 },
                    { 354, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 89 },
                    { 353, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 89 },
                    { 348, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 87 },
                    { 347, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 87 },
                    { 346, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 87 },
                    { 345, "https://b4.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2060/2060758.5b584677ad05b.jpeg", false, 87 },
                    { 26, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 7 },
                    { 108, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 27 },
                    { 27, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 7 },
                    { 29, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 8 },
                    { 106, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 27 },
                    { 105, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 27 },
                    { 76, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 19 },
                    { 75, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 19 },
                    { 74, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 19 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 73, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 19 },
                    { 72, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 18 },
                    { 71, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 18 },
                    { 70, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 18 },
                    { 69, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 18 },
                    { 56, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 14 },
                    { 55, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 14 },
                    { 54, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 14 },
                    { 53, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 14 },
                    { 36, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 9 },
                    { 35, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 9 },
                    { 34, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 9 },
                    { 33, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 9 },
                    { 32, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 8 },
                    { 31, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 8 },
                    { 30, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 8 },
                    { 28, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/2616/2616106.5dd68ee087e71.jpeg", false, 7 },
                    { 396, "https://b.3ddd.ru/media/cache/tuk_model_custom_filter_en/model_images/0000/0000/1256/1256782.5984720714400.jpeg", false, 99 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
