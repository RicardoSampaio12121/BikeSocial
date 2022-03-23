using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSocialDAL.Migrations
{
    public partial class UpdateTrainingsTableCreatedTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Trainings",
                newName: "dateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Trainings",
                newName: "Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Trainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
