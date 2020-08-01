using Microsoft.EntityFrameworkCore.Migrations;

namespace BBS.DataAccess.Migrations
{
    public partial class UpdateBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Branch");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Branch",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Branch",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Branch",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Branch",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Branch",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Branch");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
