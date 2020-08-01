using Microsoft.EntityFrameworkCore.Migrations;

namespace BBS.DataAccess.Migrations
{
    public partial class UpdateHospitalAndAddBranchToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Hospital");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Hospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
