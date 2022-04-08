using Microsoft.EntityFrameworkCore.Migrations;

namespace Muza.Data.Migrations
{
    public partial class ArtistProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YearCreated",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearCreated",
                table: "Artists");
        }
    }
}
