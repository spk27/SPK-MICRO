using Microsoft.EntityFrameworkCore.Migrations;

namespace Spk.Catalog.Persistence.Migrations
{
    public partial class AddingMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Territories",
                schema: "Catalog",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products",
                schema: "Catalog",
                table: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "Media",
                schema: "Catalog",
                columns: table => new
                {
                    MediaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: false),
                    Caption = table.Column<string>(maxLength: 255, nullable: true),
                    FileSize = table.Column<int>(nullable: true),
                    MediaType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaID);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                schema: "Catalog",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false),
                    MediaID = table.Column<long>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => new { x.ProductID, x.MediaID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Media_MediaID",
                        column: x => x.MediaID,
                        principalSchema: "Catalog",
                        principalTable: "Media",
                        principalColumn: "MediaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMedias_Products",
                        column: x => x.ProductID,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_MediaID",
                schema: "Catalog",
                table: "ProductMedia",
                column: "MediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products",
                schema: "Catalog",
                table: "ProductCategory",
                column: "CategoryID",
                principalSchema: "Catalog",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories",
                schema: "Catalog",
                table: "ProductCategory",
                column: "ProductID",
                principalSchema: "Catalog",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products",
                schema: "Catalog",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories",
                schema: "Catalog",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductMedia",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Media",
                schema: "Catalog");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Territories",
                schema: "Catalog",
                table: "ProductCategory",
                column: "CategoryID",
                principalSchema: "Catalog",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products",
                schema: "Catalog",
                table: "ProductCategory",
                column: "ProductID",
                principalSchema: "Catalog",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
