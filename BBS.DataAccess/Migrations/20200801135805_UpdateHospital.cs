using Microsoft.EntityFrameworkCore.Migrations;

namespace BBS.DataAccess.Migrations
{
    public partial class UpdateHospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Hospital");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Hospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Hospital",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Hospital",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
