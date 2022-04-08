using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Muza.Data.Migrations
{
    public partial class UpdatedArtistEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreatedUtc",
                table: "Artists");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedUtc",
                table: "Artists",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedUtc",
                table: "Artists",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedUtc",
                table: "ArtistRatings",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ModifiedUtc",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ModifiedUtc",
                table: "ArtistRatings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreatedUtc",
                table: "Artists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
