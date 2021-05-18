using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTier.Migrations
{
    public partial class UpdatedCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "CustomersTable",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomerCprNumber",
                table: "AccountTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTable_CustomerCprNumber",
                table: "AccountTable",
                column: "CustomerCprNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTable_CustomersTable_CustomerCprNumber",
                table: "AccountTable",
                column: "CustomerCprNumber",
                principalTable: "CustomersTable",
                principalColumn: "CprNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTable_CustomersTable_CustomerCprNumber",
                table: "AccountTable");

            migrationBuilder.DropIndex(
                name: "IX_AccountTable_CustomerCprNumber",
                table: "AccountTable");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "CustomersTable");

            migrationBuilder.DropColumn(
                name: "CustomerCprNumber",
                table: "AccountTable");
        }
    }
}
