using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTier.Migrations
{
    public partial class AccountNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTable_CustomersTable_CustomerCprNumber",
                table: "AccountTable");

            migrationBuilder.DropIndex(
                name: "IX_AccountTable_CustomerCprNumber",
                table: "AccountTable");

            migrationBuilder.DropColumn(
                name: "CustomerCprNumber",
                table: "AccountTable");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AccountTable",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTable_Username",
                table: "AccountTable",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTable_UsersTable_Username",
                table: "AccountTable",
                column: "Username",
                principalTable: "UsersTable",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTable_UsersTable_Username",
                table: "AccountTable");

            migrationBuilder.DropIndex(
                name: "IX_AccountTable_Username",
                table: "AccountTable");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AccountTable");

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
    }
}
