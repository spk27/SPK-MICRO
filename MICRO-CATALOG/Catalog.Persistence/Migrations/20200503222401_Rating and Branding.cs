using Microsoft.EntityFrameworkCore.Migrations;

namespace Spk.Catalog.Persistence.Migrations
{
    public partial class RatingandBranding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Viewed",
                schema: "Catalog",
                table: "Product",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                schema: "Catalog",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RatingAverage",
                schema: "Catalog",
                table: "Product",
                type: "decimal(8,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                schema: "Catalog",
                table: "Product",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Catalog",
                columns: table => new
                {
                    BrandID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                schema: "Catalog",
                table: "Product",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brand",
                schema: "Catalog",
                table: "Product",
                column: "BrandId",
                principalSchema: "Catalog",
                principalTable: "Brand",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brand",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandId",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandId",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RatingAverage",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Viewed",
                schema: "Catalog",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 0);
        }
    }
}
