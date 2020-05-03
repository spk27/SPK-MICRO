using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spk.Catalog.Persistence.Catalog.Persistence.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "Catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User = table.Column<string>(maxLength: 50, nullable: true),
                    Action = table.Column<string>(maxLength: 255, nullable: true),
                    IsError = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Catalog",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Catalog",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,3)", nullable: false, defaultValue: 0m),
                    OldPrice = table.Column<decimal>(nullable: true),
                    NewPrice = table.Column<decimal>(nullable: true),
                    StockQuantity = table.Column<int>(nullable: false),
                    MinStockQuantity = table.Column<int>(nullable: false),
                    DisplayStockQuantity = table.Column<bool>(nullable: false),
                    NotifyForQuantityBelow = table.Column<bool>(nullable: false),
                    OrderMinimumQuantity = table.Column<int>(nullable: true),
                    OrderMaximumQuantity = table.Column<int>(nullable: true),
                    MarkAsNew = table.Column<bool>(nullable: false),
                    MarkAsNewStartDateTimeUtc = table.Column<DateTime>(nullable: true),
                    MarkAsNewEndDateTimeUtc = table.Column<DateTime>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(nullable: true),
                    Viewed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Catalog",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductID, x.CategoryID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Territories",
                        column: x => x.CategoryID,
                        principalSchema: "Catalog",
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products",
                        column: x => x.ProductID,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryID",
                schema: "Catalog",
                table: "ProductCategory",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Catalog");
        }
    }
}
