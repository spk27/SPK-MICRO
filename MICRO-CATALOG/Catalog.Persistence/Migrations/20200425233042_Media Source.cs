using Microsoft.EntityFrameworkCore.Migrations;

namespace Spk.Catalog.Persistence.Migrations
{
    public partial class MediaSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                schema: "Catalog",
                table: "Media",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                schema: "Catalog",
                table: "Media");
        }
    }
}
