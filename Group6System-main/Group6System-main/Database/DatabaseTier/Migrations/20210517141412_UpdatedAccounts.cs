using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTier.Migrations
{
    public partial class UpdatedAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTable_AccountTable_CustomerAccountAccountNumber",
                table: "CustomersTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTable_CustomersTable_SenderCprNumber",
                table: "TransactionTable");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTable_SenderCprNumber",
                table: "TransactionTable");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTable_CustomerAccountAccountNumber",
                table: "CustomersTable");

            migrationBuilder.DropColumn(
                name: "SenderCprNumber",
                table: "TransactionTable");

            migrationBuilder.DropColumn(
                name: "CustomerAccountAccountNumber",
                table: "CustomersTable");

            migrationBuilder.AddColumn<long>(
                name: "SenderAccountNumber",
                table: "TransactionTable",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_SenderAccountNumber",
                table: "TransactionTable",
                column: "SenderAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTable_AccountTable_SenderAccountNumber",
                table: "TransactionTable",
                column: "SenderAccountNumber",
                principalTable: "AccountTable",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTable_AccountTable_SenderAccountNumber",
                table: "TransactionTable");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTable_SenderAccountNumber",
                table: "TransactionTable");

            migrationBuilder.DropColumn(
                name: "SenderAccountNumber",
                table: "TransactionTable");

            migrationBuilder.AddColumn<int>(
                name: "SenderCprNumber",
                table: "TransactionTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerAccountAccountNumber",
                table: "CustomersTable",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTable_SenderCprNumber",
                table: "TransactionTable",
                column: "SenderCprNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_CustomerAccountAccountNumber",
                table: "CustomersTable",
                column: "CustomerAccountAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTable_AccountTable_CustomerAccountAccountNumber",
                table: "CustomersTable",
                column: "CustomerAccountAccountNumber",
                principalTable: "AccountTable",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTable_CustomersTable_SenderCprNumber",
                table: "TransactionTable",
                column: "SenderCprNumber",
                principalTable: "CustomersTable",
                principalColumn: "CprNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
