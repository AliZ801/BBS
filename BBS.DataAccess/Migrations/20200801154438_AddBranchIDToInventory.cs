using Microsoft.EntityFrameworkCore.Migrations;

namespace BBS.DataAccess.Migrations
{
    public partial class AddBranchIDToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BranchId",
                table: "Inventory",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Branch_BranchId",
                table: "Inventory",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Branch_BranchId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_BranchId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Inventory");
        }
    }
}
