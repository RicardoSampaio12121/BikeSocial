using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSocialDAL.Migrations
{
    public partial class UpdatePlaceTableCreatedTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Locale",
                table: "Places",
                newName: "Town");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Places",
                newName: "Locale");
        }
    }
}
