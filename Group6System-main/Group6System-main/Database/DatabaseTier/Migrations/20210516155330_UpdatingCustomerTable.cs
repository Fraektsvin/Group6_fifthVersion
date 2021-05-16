using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTier.Migrations
{
    public partial class UpdatingCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "CustomersTable",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_Username",
                table: "CustomersTable",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTable_UsersTable_Username",
                table: "CustomersTable",
                column: "Username",
                principalTable: "UsersTable",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTable_UsersTable_Username",
                table: "CustomersTable");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTable_Username",
                table: "CustomersTable");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "CustomersTable");
        }
    }
}
